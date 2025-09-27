using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manange_Furniture.controllers;
using Sales_Manage_Furniture.models;
using Sales_Manange_Furniture.models;
using System.Data.SqlClient;
using Guna.UI2.AnimatorNS;

namespace Sales_Manange_Furniture.views
{
    public partial class UCKhuyenMai : UserControl
    {
        KhuyenMaiController kmCtrl = new KhuyenMaiController();
        ChiTietKhuyenMaiController ctkmCtrl = new ChiTietKhuyenMaiController();
        public UCKhuyenMai()
        {
            InitializeComponent();
        }

        private void tp_KhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadKhuyenMai();
            LoadChiTietKhuyenMai();
        }

        private void LoadChiTietKhuyenMai()

        {
            List<ChiTietKhuyenMai> ctkm = ctkmCtrl.GetAll();
            dgv_ChiTietKhuyenMai.AutoGenerateColumns = false;
            dgv_ChiTietKhuyenMai.DataSource = ctkm;
            kmCtrl.LoadComboboxes(cbb_ChuongTrinhKM, cbb_SanPham);
            btn_Them2.Enabled = true;
            btn_Luu2.Enabled = false;
            btn_Sua2.Enabled = false;
            btn_Xoa2.Enabled = false;
            btn_Huy2.Enabled = false;
        }

        private void LoadKhuyenMai()
        {
            List<KhuyenMai> km = kmCtrl.GetAll();
            dgv_KhuyenMai.AutoGenerateColumns = false;
            dgv_KhuyenMai.DataSource = km;
            btn_Them.Enabled = true;
            btn_Luu.Enabled = false;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Huy.Enabled = false;
        }


        private void dgv_KhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // đảm bảo không click vào header
            {
                DataGridViewRow row = dgv_KhuyenMai.Rows[e.RowIndex];

                // Gán dữ liệu vào control
                txt_MaKM.Text = row.Cells["col_MaKH"].Value?.ToString();
                txt_TenCT.Text = row.Cells["col_TenKM"].Value?.ToString();
                cbb_LoaiKhuyenMai.Text = row.Cells["col_LoaiKM"].Value?.ToString();
                txt_GiaTri.Text = row.Cells["col_GiaTri"].Value?.ToString();

                if (row.Cells["col_NgayBatDau"].Value != null)
                    dtp_BatDau.Value = Convert.ToDateTime(row.Cells["col_NgayBatDau"].Value);

                if (row.Cells["col_NgayKetThuc"].Value != null)
                    dtp_KetThuc.Value = Convert.ToDateTime(row.Cells["col_NgayKetThuc"].Value);

                // Nếu TrangThai kiểu bool (true/false)
                if (row.Cells["col_TrangThai"].Value != null)
                {
                    bool trangThai = Convert.ToBoolean(row.Cells["col_TrangThai"].Value);
                    cbb_TrangThai.Text = trangThai ? "Đang hoạt động" : "Ngừng";
                }

                rtb_MoTa.Text = row.Cells["col_MoTa"].Value?.ToString();

                btn_Huy.Enabled = true;
                btn_Them.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }



        private void dgv_ChiTietKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_ChiTietKhuyenMai.Rows[e.RowIndex];
                cbb_ChuongTrinhKM.Text = row.Cells["col_TenKMM"].Value.ToString();
                cbb_SanPham.Text = row.Cells["col_TenSP"].Value.ToString();
                txt_GiaTriApDung.Text = row.Cells["col_GiaTriApDung"].Value.ToString();
                cbb_Loai.Text = row.Cells["col_KieuKM"].Value.ToString();

                btn_Huy2.Enabled = true;
                btn_Them2.Enabled = false;
                btn_Luu2.Enabled = false;
                btn_Sua2.Enabled = true;
                btn_Xoa2.Enabled = true;

            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_MaKM.Clear();
            txt_TenCT.Clear();
            cbb_LoaiKhuyenMai.SelectedIndex = -1;
            txt_GiaTri.Clear();
            cbb_TrangThai.SelectedIndex = -1;
            rtb_MoTa.Clear();
            dtp_BatDau.Value = DateTime.Now;
            dtp_KetThuc.Value = DateTime.Now;
            txt_TenCT.Focus();
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            btn_Huy.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                if (string.IsNullOrEmpty(txt_MaKM.Text))
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!");
                    return;
                }

                int maKM = int.Parse(txt_MaKM.Text.Trim());
                string tenCT = txt_TenCT.Text.Trim();
                string loaiKM = cbb_LoaiKhuyenMai.Text.Trim();
                string giaTri = txt_GiaTri.Text.Trim();
                DateTime ngayBatDau = dtp_BatDau.Value;
                DateTime ngayKetThuc = dtp_KetThuc.Value;
                string moTa = rtb_MoTa.Text.Trim();

                if (string.IsNullOrEmpty(tenCT) || string.IsNullOrEmpty(loaiKM) || string.IsNullOrEmpty(giaTri))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khuyến mãi!");
                    return;
                }

                // Convert combobox về bool
                bool trangThai = cbb_TrangThai.Text == "Đang áp dụng";
                // Tạo đối tượng KhuyenMai
                KhuyenMai km = new KhuyenMai
                {
                    MaKM = maKM,
                    TenKM = tenCT,
                    LoaiKM = loaiKM,
                    GiaTriKM = decimal.Parse(giaTri), // đổi sang int.Parse nếu kiểu số nguyên
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    TrangThai = trangThai,
                    MoTa = moTa
                };

                // Gọi Update
                int result = kmCtrl.Update(km);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật khuyến mãi thành công!");
                    LoadKhuyenMai();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
            btn_Sua.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Them.Enabled = false;
            btn_Huy.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_MaKM.Text))
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!");
                    return;
                }
                int maKM = int.Parse(txt_MaKM.Text.Trim());
                // Xác nhận xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int result = kmCtrl.Delete(maKM);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công!");
                        LoadKhuyenMai();
                        // Xoá dữ liệu trong form
                        txt_MaKM.Clear();
                        txt_TenCT.Clear();
                        cbb_LoaiKhuyenMai.SelectedIndex = -1;
                        txt_GiaTri.Clear();
                        cbb_TrangThai.SelectedIndex = -1;
                        rtb_MoTa.Clear();
                        dtp_BatDau.Value = DateTime.Now;
                        dtp_KetThuc.Value = DateTime.Now;
                        btn_Them.Enabled = true;
                        btn_Luu.Enabled = false;
                        btn_Sua.Enabled = false;
                        btn_Xoa.Enabled = false;
                        btn_Huy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txt_MaKM.Clear();
            txt_TenCT.Clear();
            cbb_LoaiKhuyenMai.SelectedIndex = -1;
            txt_GiaTri.Clear();
            cbb_TrangThai.SelectedIndex = -1;
            rtb_MoTa.Clear();
            dtp_BatDau.Value = DateTime.Now;
            dtp_KetThuc.Value = DateTime.Now;
            btn_Huy.Enabled = false;
            btn_Them.Enabled = true;
            btn_Luu.Enabled = false;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string tenCT = txt_TenCT.Text.Trim();
                string loaiKM = cbb_LoaiKhuyenMai.Text.Trim();
                string giaTri = txt_GiaTri.Text.Trim();
                DateTime ngayBatDau = dtp_BatDau.Value;
                DateTime ngayKetThuc = dtp_KetThuc.Value;
                string trangThaiStr = cbb_TrangThai.Text.Trim();
                string moTa = rtb_MoTa.Text.Trim();

                // Kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrEmpty(tenCT) || string.IsNullOrEmpty(loaiKM) || string.IsNullOrEmpty(giaTri))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khuyến mãi!");
                    return;
                }

                // Chuyển đổi giá trị
                if (!decimal.TryParse(giaTri, out decimal giaTriKM))
                {
                    MessageBox.Show("Giá trị khuyến mãi phải là số!");
                    return;
                }

                // Chuyển đổi trạng thái từ combobox -> bool
                bool trangThai = (trangThaiStr == "Đang hoạt động");

                // Tạo đối tượng KhuyenMai
                KhuyenMai km = new KhuyenMai
                {
                    TenKM = tenCT,
                    LoaiKM = loaiKM,
                    GiaTriKM = giaTriKM,
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    TrangThai = trangThai,  // bool
                    MoTa = moTa
                };

                // Gọi hàm Insert trong Controller
                int result = kmCtrl.Insert(km);

                if (result > 0)
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!");
                    LoadKhuyenMai();

                    // Xoá dữ liệu trong form
                    txt_MaKM.Clear();
                    txt_TenCT.Clear();
                    cbb_LoaiKhuyenMai.SelectedIndex = -1;
                    txt_GiaTri.Clear();
                    cbb_TrangThai.SelectedIndex = -1;
                    rtb_MoTa.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
            btn_Luu.Enabled = false;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Huy.Enabled = false;

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_Tim.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                // Gọi controller để tìm kiếm
                DataTable dt = kmCtrl.Search(keyword);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_KhuyenMai.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khuyến mãi nào!");
                    dgv_KhuyenMai.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trên form
            txt_MaKM.Clear();
            txt_TenCT.Clear();
            cbb_LoaiKhuyenMai.SelectedIndex = -1;
            txt_GiaTri.Clear();
            dtp_BatDau.Value = DateTime.Now;
            dtp_KetThuc.Value = DateTime.Now;
            cbb_TrangThai.SelectedIndex = -1;
            rtb_MoTa.Clear();

            // Load lại DataGridView
            LoadKhuyenMai();
        }

        private void btn_Them2_Click(object sender, EventArgs e)
        {
            cbb_ChuongTrinhKM.SelectedIndex = -1;
            cbb_SanPham.SelectedIndex = -1;
            cbb_Loai.SelectedIndex = -1;
            cbb_ChuongTrinhKM.Focus();
            txt_GiaTriApDung.Clear();
            btn_Luu2.Enabled = true;
            btn_Them2.Enabled = false;
            btn_Huy2.Enabled = true;
            btn_Sua2.Enabled = false;
            btn_Xoa2.Enabled = false;
        }

        private void btn_Sua2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_ChuongTrinhKM.SelectedIndex < 0 || cbb_SanPham.SelectedIndex < 0 || string.IsNullOrEmpty(txt_GiaTriApDung.Text))
                {
                    MessageBox.Show("Vui lòng chọn chi tiết khuyến mãi cần sửa!");
                    return;
                }

                // Lấy dữ liệu từ form
                int maKM = Convert.ToInt32(cbb_ChuongTrinhKM.SelectedValue); // ID chương trình KM
                int maSP = Convert.ToInt32(cbb_SanPham.SelectedValue);       // ID sản phẩm
                string kieuKM = cbb_Loai.Text.Trim();
                decimal giaTri = decimal.Parse(txt_GiaTriApDung.Text.Trim());

                // Tạo object mới
                ChiTietKhuyenMai ctkm = new ChiTietKhuyenMai
                {
                    MaKM = maKM,
                    MaSP = maSP,
                    KieuKM = kieuKM,
                    GiaTriApDung = giaTri
                };

                // Gọi Update
                int result = ctkmCtrl.Update(ctkm);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật chi tiết khuyến mãi thành công!");
                    LoadChiTietKhuyenMai(); // refresh lại grid
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa chi tiết: " + ex.Message);
            }
            btn_Sua.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Them.Enabled = false;
            btn_Huy.Enabled = true;
        }


        private void btn_Luu2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (cbb_ChuongTrinhKM.SelectedIndex < 0 || cbb_SanPham.SelectedIndex < 0 || string.IsNullOrEmpty(txt_GiaTriApDung.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết khuyến mãi!");
                    return;
                }

                // Lấy giá trị từ combobox
                int maKM = Convert.ToInt32(cbb_ChuongTrinhKM.SelectedValue); // hoặc int.Parse(cbb_MaKM.Text)
                int maSP = Convert.ToInt32(cbb_SanPham.SelectedValue); // hoặc int.Parse(cbb_MaSP.Text)
                string kieuKM = cbb_Loai.Text.Trim();
                decimal giaTri = decimal.Parse(txt_GiaTriApDung.Text.Trim());

                // Tạo đối tượng ChiTietKhuyenMai
                ChiTietKhuyenMai ctkm = new ChiTietKhuyenMai
                {
                    MaKM = maKM,
                    MaSP = maSP,
                    KieuKM = kieuKM,
                    GiaTriApDung = giaTri
                };

                // Gọi Insert
                int result = ctkmCtrl.Insert(ctkm);

                if (result > 0)
                {
                    MessageBox.Show("Thêm chi tiết khuyến mãi thành công!");
                    LoadChiTietKhuyenMai();
                    cbb_SanPham.SelectedIndex = -1;
                    cbb_Loai.SelectedIndex = -1;
                    txt_GiaTriApDung.Clear();
                    cbb_Loai.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết: " + ex.Message);
            }
            btn_Luu2.Enabled = false;
            btn_Them2.Enabled = true;
            btn_Sua2.Enabled = false;
            btn_Xoa2.Enabled = false;
            btn_Huy2.Enabled = false;

        }

        private void btn_Xoa2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_ChuongTrinhKM.SelectedIndex < 0 || cbb_SanPham.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết khuyến mãi cần xóa!");
                    return;
                }

                int maKM = Convert.ToInt32(cbb_ChuongTrinhKM.SelectedValue);
                int maSP = Convert.ToInt32(cbb_SanPham.SelectedValue);

                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc muốn xóa chi tiết khuyến mãi này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dr == DialogResult.Yes)
                {
                    int result = ctkmCtrl.Delete(maKM, maSP);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa chi tiết khuyến mãi thành công!");
                        LoadChiTietKhuyenMai();
                        cbb_SanPham.SelectedIndex = -1;
                        cbb_Loai.SelectedIndex = -1;
                        txt_GiaTriApDung.Clear();
                        cbb_Loai.SelectedIndex = -1;
                        btn_Them2.Enabled = true;
                        btn_Luu2.Enabled = false;
                        btn_Sua2.Enabled = false;
                        btn_Xoa2.Enabled = false;
                        btn_Huy2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết: " + ex.Message);


            }
            

        }

        private void btn_Huy2_Click(object sender, EventArgs e)
        {
            cbb_ChuongTrinhKM.SelectedIndex = -1;
            cbb_SanPham.SelectedIndex = -1;
            cbb_Loai.SelectedIndex = -1;
            txt_GiaTriApDung.Clear();
            btn_Huy2.Enabled = false;
            btn_Them2.Enabled = true;
            btn_Luu2.Enabled = false;
            btn_Sua2.Enabled = false;
            btn_Xoa2.Enabled = false;
        }

        private void btn_Tim2_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_Tim2.Text.Trim(); // TextBox nhập từ khóa tìm kiếm

                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                DataTable dt = ctkmCtrl.Search(keyword);

                if (dt.Rows.Count > 0)
                {
                    dgv_ChiTietKhuyenMai.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết khuyến mãi nào!");
                    dgv_ChiTietKhuyenMai.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btn_LamMoi2_Click(object sender, EventArgs e)
        {
            cbb_ChuongTrinhKM.SelectedIndex = -1;
            cbb_SanPham.SelectedIndex = -1;
            cbb_Loai.SelectedIndex = -1;
            txt_GiaTriApDung.Clear();
            LoadChiTietKhuyenMai();
        }
    }
}
