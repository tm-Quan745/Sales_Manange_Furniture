using System;
using System.Windows.Forms;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.controllers;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections.Generic;

namespace Sales_Manange_Furniture.views
{
    public partial class UCBanHang : UserControl
    {
        SanPhamController spCtrl;
        LoginController lgCtrl = new LoginController() ;
        GioHangController ghCtrl;   // ✅ Controller giỏ hàng
        HoaDonController hdCtrl;
        ChiTietHDBController cthdCtrl;
        KhachHangController khCtrl;
        bool checkKH = false; // Biến kiểm tra đã tìm thấy khách hàng hay chưa
        NhanVien _nv = new NhanVien();
        int _maSP;

        int SoLuongTonKho = 0; // Biến lưu số lượng tồn kho của sản phẩm hiện tại
        string danhsachKM = "";

        public UCBanHang(NhanVien nv, int maSP)
        {
            InitializeComponent();
            _maSP = maSP;
            spCtrl = new SanPhamController(lgCtrl.USER_NAME);
            khCtrl = new KhachHangController(lgCtrl.USER_NAME);
            cthdCtrl = new ChiTietHDBController(lgCtrl.USER_NAME);
            hdCtrl = new HoaDonController(lgCtrl.USER_NAME);
            _nv = nv;
            ghCtrl = new GioHangController(dgv_GioHang, txt_TamTinh, txt_ChietKhau, txt_VAT, txt_TongTien);
            
        }


        private void LoadGioHang(string sessionID)
        {
            DataTable dt = ghCtrl.GetGioHang(sessionID);

            dgv_GioHang.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgv_GioHang.Rows.Add();
                int idx = dgv_GioHang.Rows.Count - 1;
                dgv_GioHang.Rows[idx].Cells["col_TenSP"].Value = row["TenSP"];
                dgv_GioHang.Rows[idx].Cells["col_DonGia"].Value = row["GiaBan"];
                dgv_GioHang.Rows[idx].Cells["col_SoLuongb"].Value = row["SoLuong"];
                dgv_GioHang.Rows[idx].Cells["col_KM"].Value = row["DanhSachKM"];
                dgv_GioHang.Rows[idx].Cells["col_Tong"].Value = row["ThanhTien"];
                dgv_GioHang.Rows[idx].Cells["col_MaSP"].Value = row["MaSP"]; // ✅ đảm bảo đúng

            }

            // Gọi controller để tính tổng
            ghCtrl.CapNhatThanhTien(sessionID, txt_TamTinh, txt_ChietKhau, txt_VAT, txt_TongTien);
        }
        private void UCBanHang_Load(object sender, EventArgs e)
        {
            // Gắn dgv + các textbox vào controller

            LoadGioHang(SessionManager.CurrentSessionID);
            // Setup dgv sản phẩm
            dgv_SanPham2.AutoGenerateColumns = false;
            dgv_SanPham2.Columns.Clear();
            dgv_SanPham2.Columns.Add("MaSPCol", "Mã SP");
            dgv_SanPham2.Columns.Add("TenSPCol", "Tên sản phẩm");
            dgv_SanPham2.Columns.Add("GiaBanCol", "Giá bán");
            dgv_SanPham2.Columns["GiaBanCol"].DefaultCellStyle.Format = "N0";
            dgv_SanPham2.Columns.Add("SoLuongCol", "Số lượng");

            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            btnAdd.HeaderText = "";
            btnAdd.Text = "+";
            btnAdd.Name = "btnAdd";
            btnAdd.UseColumnTextForButtonValue = true;
            dgv_SanPham2.Columns.Add(btnAdd);

            dgv_SanPham2.Columns["btnAdd"].Width = 40;
            dgv_SanPham2.Columns["btnAdd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SanPham2.RowTemplate.Height = 35;
            LoadSanPham();
            hightlight();

        }
        
        private void hightlight()
        {
            if (_maSP != 0)
            {              
                foreach (DataGridViewRow row in dgv_SanPham2.Rows)
                {
                    if (Convert.ToInt32(row.Cells["MaSPCol"].Value) == _maSP)
                    {
                        row.Selected = true;
                        dgv_SanPham2.FirstDisplayedScrollingRowIndex = row.Index; // Cuộn đến hàng được chọn
                        break;
                    }
                }

            }
        }
        private void LoadSanPham()
        {
            // Load dữ liệu
            var listSanPham = spCtrl.Showdgv();
            foreach (var sp in listSanPham)
            {
                int rowIndex = dgv_SanPham2.Rows.Add();
                dgv_SanPham2.Rows[rowIndex].Cells["MaSPCol"].Value = sp.MaSP;
                dgv_SanPham2.Rows[rowIndex].Cells["TenSPCol"].Value = sp.TenSP;
                dgv_SanPham2.Rows[rowIndex].Cells["GiaBanCol"].Value = sp.GiaBan;
                dgv_SanPham2.Rows[rowIndex].Cells["SoLuongCol"].Value = sp.SoLuongTon;
            }
        }
        void AddButtonColumn(string name, string text, int width)
        {
            if (!dgv_GioHang.Columns.Contains(name))
            {
                var btn = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = text,
                    Name = name,
                    Width = width,
                    UseColumnTextForButtonValue = true
                };
                dgv_GioHang.Columns.Add(btn);
            }
        }


        private void InitGioHang()
        {
           
            // Format cột Tên sản phẩm
            dgv_GioHang.Columns["col_TenSP"].Width=120;

            dgv_GioHang.Columns["col_KM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_GioHang.Columns["col_SoLuongb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_GioHang.Columns["col_SoLuongb"].Width = 50;
            // Format số
            dgv_GioHang.Columns["col_DonGia"].DefaultCellStyle.Format = "N0";
            dgv_GioHang.Columns["col_DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

           

            dgv_GioHang.Columns["col_Tong"].DefaultCellStyle.Format = "N0";
            dgv_GioHang.Columns["col_Tong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_GioHang.Columns["col_MaSP"].Visible = false;

            // Cột button
            AddButtonColumn("btnPlus", "+", 10);
            AddButtonColumn("btnMinus", "-", 10);

            dgv_GioHang.RowTemplate.Height = 35;
            dgv_GioHang.AllowUserToAddRows = false;
        }


        private void dgv_SanPham2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_SanPham2.Rows.Count)
                return;

            InitGioHang();

            // ✅ Lấy mã sản phẩm và số lượng tồn kho
            int maSP = Convert.ToInt32(dgv_SanPham2.Rows[e.RowIndex].Cells["MaSPCol"].Value);
            SoLuongTonKho = Convert.ToInt32(dgv_SanPham2.Rows[e.RowIndex].Cells["SoLuongCol"].Value);

            if (dgv_SanPham2.Columns[e.ColumnIndex].Name == "btnAdd")
            {
                string sessionID = SessionManager.CurrentSessionID;

                // ✅ Kiểm tra hàng tồn
                if (SoLuongTonKho <= 0)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Tìm xem sản phẩm đã có trong dgv_GioHang chưa
                int soLuongTrongGio = 0;
                foreach (DataGridViewRow row in dgv_GioHang.Rows)
                {
                    if (row.Cells["col_MaSP"].Value != null &&
                        Convert.ToInt32(row.Cells["col_MaSP"].Value) == maSP)
                    {
                        soLuongTrongGio = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
                        break;
                    }
                }

                // ✅ Nếu tổng sau khi thêm > tồn kho → chặn
                if (soLuongTrongGio + 1 > SoLuongTonKho)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Gọi SP thêm vào giỏ (tăng 1)
                ghCtrl.ThemVaoGio(sessionID, maSP, 1, "");

                // ✅ Load lại giỏ hàng từ DB
                LoadGioHang(sessionID);

                // ✅ Cập nhật lại tổng tiền
                ghCtrl.CapNhatThanhTien(sessionID, txt_TamTinh, txt_ChietKhau, txt_VAT, txt_TongTien);
            }
        }


        private void dgv_GioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_GioHang.Rows.Count)
                return;

            DataGridViewRow row = dgv_GioHang.Rows[e.RowIndex];

            // Lấy số lượng hiện tại và tồn kho
            int sl = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
            int slTon = SoLuongTonKho;

            // Lấy đơn giá
            decimal donGia = Convert.ToDecimal(row.Cells["col_DonGia"].Value);
            int maSP = Convert.ToInt32(row.Cells["col_MaSP"].Value);
            string colName = dgv_GioHang.Columns[e.ColumnIndex].Name;
            string DanhSachKM = dgv_GioHang.Rows[e.RowIndex].Cells["col_KM"].Value.ToString();
            string sessionID = SessionManager.CurrentSessionID;

            if (colName == "btnPlus")
            {
                if (sl < slTon)
                {
                    // Gọi SP thêm vào giỏ
                    ghCtrl.ThemVaoGio(sessionID, maSP, 1, DanhSachKM);

                    // Load lại giỏ hàng từ DB
                    LoadGioHang(sessionID);
                }
                else
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "btnMinus")
            {
                if (sl > 1)
                {
                    // Gọi SP thêm vào giỏ
                    ghCtrl.ThemVaoGio(sessionID, maSP, -1, DanhSachKM);

                    // Load lại giỏ hàng từ DB
                    LoadGioHang(sessionID);
                }
                else
                {
                    ghCtrl.XoaKhoiGio(sessionID, maSP);
                    LoadGioHang(sessionID);
                }
            }
            
            // ✅ luôn cập nhật lại tổng tiền sau khi sửa giỏ hàng
            ghCtrl.CapNhatThanhTien(sessionID, txt_TamTinh, txt_ChietKhau, txt_VAT, txt_TongTien);
        }






        private void txt_VAT_TextChanged(object sender, EventArgs e)
        {
                    }

        private void btn_HuyAll_Click(object sender, EventArgs e)
        {
            string sessionID = SessionManager.CurrentSessionID;
            MessageBox.Show("Bạn có chắc muốn hủy toàn bộ giỏ hàng?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            ghCtrl.HuyGioHang(sessionID);
            txt_SDT.Text = "";
            txt_TenKH.Text = "";
            LoadGioHang(sessionID);
        }

        private DataTable ConvertGioHangToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Cấu trúc phải giống dbo.CTHoaDonType
            dt.Columns.Add("MaSP", typeof(int));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(decimal));
            dt.Columns.Add("DanhSachKM", typeof(string));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                int maSP = Convert.ToInt32(row.Cells["col_MaSP"].Value);
                int soLuong = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
                decimal donGia = Convert.ToDecimal(row.Cells["col_DonGia"].Value);
                string dsKM = row.Cells["col_KM"].Value?.ToString() ?? "";
                dt.Rows.Add(maSP, soLuong, donGia, dsKM);
            }

            return dt;
        }

        private int ThemHoaDonFull(HoaDon hd, DataTable dtCTHD)
        {
            // Gọi SP để thêm hóa đơn và chi tiết hóa đơn
            int newMaHDB = hdCtrl.ThemHoaDonFull(hd, dtCTHD);
            return newMaHDB;
        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            FThanhToan ftt;
            string sessionID = SessionManager.CurrentSessionID;
            if (dgv_GioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_SDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SDT.Focus();
                return;
            }
            // Lưu hóa đơn
            if (checkKH == false && txt_TenKH != null)
            {
                khCtrl.Insert(new KhachHang
                {
                    HoTen = txt_TenKH.Text,
                    SoDienThoai = txt_SDT.Text
                });
                HoaDon hd = new HoaDon
                {
                    MaKH = khCtrl.GetByPhone(txt_SDT.Text).MaKH,
                    MaNV = _nv.MaNV,
                    NgayBan = DateTime.Now,
                    TienTamTinh = Convert.ToDecimal(txt_TamTinh.Text.Replace(",", "")),
                    ThueVAT = Convert.ToDecimal(txt_VAT.Text.Replace(",", "")),
                    ChietKhau = Convert.ToDecimal(txt_ChietKhau.Text.Replace(",", "")),
                    TongTien = Convert.ToDecimal(txt_TongTien.Text.Replace(",", "")),
                    TrangThai = "Chưa thanh toán"
                };

                DataTable dtCTHD = ConvertGioHangToDataTable(dgv_GioHang);

                int newMaHDB = ThemHoaDonFull(hd, dtCTHD);
                ftt = new FThanhToan(newMaHDB,txt_TongTien.Text);

            }
            else
            {
                HoaDon hd = new HoaDon
                {
                    MaKH = khCtrl.GetByPhone(txt_SDT.Text).MaKH,
                    MaNV = _nv.MaNV,
                    NgayBan = DateTime.Now,
                    TienTamTinh = Convert.ToDecimal(txt_TamTinh.Text.Replace(",", "")),
                    ThueVAT = Convert.ToDecimal(txt_VAT.Text.Replace(",", "")),
                    ChietKhau = Convert.ToDecimal(txt_ChietKhau.Text.Replace(",", "")),
                    TongTien = Convert.ToDecimal(txt_TongTien.Text.Replace(",", "")),
                    TrangThai = "Chưa thanh toán"
                };

                // Convert giỏ hàng thành DataTable
                DataTable dtCTHD = ConvertGioHangToDataTable(dgv_GioHang);

                // Gọi SP lưu toàn bộ
                int newMaHDB = ThemHoaDonFull(hd, dtCTHD);

                ftt = new FThanhToan(newMaHDB,txt_TongTien.Text);
            }

            MessageBox.Show("Đã lưu hoá đơn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ghCtrl.HuyGioHang(sessionID);
            LoadGioHang(sessionID);
            txt_SDT.Text = "";
            txt_TenKH.Text = "";
            ftt.ShowDialog();
            LoadSanPham();

        }

        private void btn_TimKH_Click(object sender, EventArgs e)
        {
            if(txt_SDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SDT.Focus();
                return;
            }
            if (txt_SDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ (10 số)!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SDT.Focus();
                return;
            }
            // Tìm khách hàng
            KhachHang kh = khCtrl.GetByPhone(txt_SDT.Text);
            if (kh == null)
            {
                MessageBox.Show("Khách hàng chưa tồn tại!", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_TenKH.Focus();
                checkKH = false;
                return;
            }
            else
            {
                txt_TenKH.Text = kh.HoTen;
                checkKH = true;
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string input = txt_TimSP.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập tên, mã hoặc mô tả sản phẩm cần tìm!");
                return;
            }

            List<SanPham> result = spCtrl.Search(input); // Search theo tên

            // Xóa dữ liệu cũ
            dgv_SanPham2.Rows.Clear();
            foreach (var sp in result)
            {
                int rowIndex = dgv_SanPham2.Rows.Add();
                dgv_SanPham2.Rows[rowIndex].Cells["MaSPCol"].Value = sp.MaSP;
                dgv_SanPham2.Rows[rowIndex].Cells["TenSPCol"].Value = sp.TenSP;
                dgv_SanPham2.Rows[rowIndex].Cells["GiaBanCol"].Value = sp.GiaBan;
                dgv_SanPham2.Rows[rowIndex].Cells["SoLuongCol"].Value = sp.SoLuongTon;
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadSanPham();
            txt_TimSP.Text = "";
        }
    }
}
