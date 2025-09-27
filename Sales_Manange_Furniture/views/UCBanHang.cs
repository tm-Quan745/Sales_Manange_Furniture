using System;
using System.Windows.Forms;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.controllers;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Sales_Manange_Furniture.views
{
    public partial class UCBanHang : UserControl
    {
        SanPhamController spCtrl = new SanPhamController();
        GioHangController ghCtrl;   // ✅ Controller giỏ hàng
        HoaDonController hdCtrl = new HoaDonController();
        ChiTietHDBController cthdCtrl = new ChiTietHDBController();
        KhachHangController khCtrl = new KhachHangController();
        bool checkKH = false; // Biến kiểm tra đã tìm thấy khách hàng hay chưa
        NhanVien _nv = new NhanVien();

        int SoLuongTonKho = 0; // Biến lưu số lượng tồn kho của sản phẩm hiện tại
        public UCBanHang(NhanVien nv)
        {
            InitializeComponent();
            _nv = nv;
            ghCtrl = new GioHangController(dgv_GioHang, txt_TamTinh, txt_ChietKhau, txt_VAT, txt_TongTien);
        }
       

        private void UCBanHang_Load(object sender, EventArgs e)
        {
            // Gắn dgv + các textbox vào controller
            

            
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

            dgv_GioHang.Columns["col_VAT"].Visible = false;
            dgv_GioHang.Columns["col_MaSP"].Visible = false;
            dgv_GioHang.Columns["col_MaKM"].Visible = false;

            // Cột button
            AddButtonColumn("btnPlus", "+", 10);
            AddButtonColumn("btnMinus", "-", 10);

            dgv_GioHang.RowTemplate.Height = 35;
            dgv_GioHang.AllowUserToAddRows = false;
        }

        
        // 🛒 Thêm sản phẩm vào giỏ
        private void dgv_SanPham2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InitGioHang();

            if (dgv_SanPham2.Columns[e.ColumnIndex].Name == "btnAdd" && e.RowIndex >= 0)
            {
                // Lấy thông tin sản phẩm
                int maSP = Convert.ToInt32(dgv_SanPham2.Rows[e.RowIndex].Cells["MaSPCol"].Value);
                GioHang gioHang = ghCtrl.GetSanPhamFromDB(maSP, 1);
                string kieuKM = gioHang.KieuKM;
                decimal giaTriApDung = gioHang.GiaTriApDung;
                decimal thueVAT = gioHang.ThueVAT;
                int maKM = gioHang.MaKM;
                string tenSP = dgv_SanPham2.Rows[e.RowIndex].Cells["TenSPCol"].Value.ToString();
                decimal donGia = Convert.ToDecimal(dgv_SanPham2.Rows[e.RowIndex].Cells["GiaBanCol"]. Value);
                int SoLT = Convert.ToInt32(dgv_SanPham2.Rows[e.RowIndex].Cells["SoLuongCol"].Value);
                SoLuongTonKho = SoLT;
                // Thêm hoặc tăng số lượng trong giỏ
                bool daTonTai = false;
                string giatriKM;

                if (kieuKM == "PERCENT")
                {
                    giatriKM = giaTriApDung + "%";
                }
                else
                {
                    giatriKM = giaTriApDung.ToString("N0") ; // Ensures it's formatted correctly (e.g., "10,000 VND")
                }


                foreach (DataGridViewRow row in dgv_GioHang.Rows)
                    {
                        if (row.Cells["col_TenSP"].Value != null &&
                            row.Cells["col_TenSP"].Value.ToString() == tenSP)
                        {
                            
                            int sl = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
                            if (sl < SoLT)
                            {
                                sl++;
                                row.Cells["col_SoLuongb"].Value = sl;
                                row.Cells["col_KM"].Value = giatriKM;
                                row.Cells["col_Tong"].Value = ghCtrl.TinhTienDong(donGia, sl);
                                row.Cells["col_VAT"].Value = thueVAT;
                                row.Cells["col_MaSP"].Value = maSP;
                                row.Cells["col_MaKM"].Value = maKM;

                        }
                            else
                            {
                                MessageBox.Show("Số lượng vượt quá tồn kho!", "Thông báo",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            daTonTai = true;
                            break;
                        }
                    }

                // Nếu chưa có thì thêm mới
                if (!daTonTai)
                {
                    int soLuong = 1;
                    decimal tong = ghCtrl.TinhTienDong(donGia, soLuong);

                    // ⚠️ Lưu donGia kiểu decimal, không convert sang string
                    dgv_GioHang.Rows.Add(tenSP, donGia, soLuong, giatriKM, tong, thueVAT, maSP, maKM);
                }

                // ✅ Cập nhật lại textbox tổng tiền
                ghCtrl.CapNhatThanhTien();
                ;
            }
        }

        private void dgv_GioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_GioHang.Rows.Count == 0)
                return;

            DataGridViewRow row = dgv_GioHang.Rows[e.RowIndex];
            int sl = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
            int slTon = SoLuongTonKho;
           

            if (dgv_GioHang.Columns[e.ColumnIndex].Name == "btnPlus")
            {
                if (sl < slTon)
                {
                    sl++;
                    row.Cells["col_SoLuongb"].Value = sl;

                    decimal donGia = Convert.ToDecimal(dgv_GioHang.Rows[e.RowIndex].Cells["col_DonGia"].Value);
                    dgv_GioHang.Rows[e.RowIndex].Cells["col_Tong"].Value = ghCtrl.TinhTienDong(donGia, sl);
                }
                else
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (dgv_GioHang.Columns[e.ColumnIndex].Name == "btnMinus")
            {
                if (sl > 1)
                {
                    sl--;
                    row.Cells["col_SoLuongb"].Value = sl;
                    decimal donGia = Convert.ToDecimal(dgv_GioHang.Rows[e.RowIndex].Cells["col_DonGia"].Value);
                    dgv_GioHang.Rows[e.RowIndex].Cells["col_Tong"].Value = ghCtrl.TinhTienDong(donGia, sl);
                }
                else
                {
                    dgv_GioHang.Rows.RemoveAt(e.RowIndex);
                }
            }

            // ✅ luôn cập nhật lại tổng
            ghCtrl.CapNhatThanhTien();
        }





        private void txt_VAT_TextChanged(object sender, EventArgs e)
        {
                    }

        private void btn_HuyAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn hủy toàn bộ giỏ hàng?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            dgv_GioHang.Rows.Clear();
        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            if(dgv_GioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txt_SDT.Text == "")
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
                hdCtrl.Insert(new HoaDon
                {
                    MaNV = _nv.MaNV,
                    MaKH = khCtrl.GetByPhone(txt_SDT.Text).MaKH,
                    NgayBan = DateTime.Now,
                    TienTamTinh = Convert.ToDecimal(txt_TamTinh.Text.Replace(",", "")),
                    TongTien = Convert.ToDecimal(txt_TongTien.Text.Replace(",", "")),
                    ChietKhau = Convert.ToDecimal(txt_ChietKhau.Text.Replace(",", "")),
                    ThueVAT = Convert.ToDecimal(txt_VAT.Text.Replace(",", "")),
                    TrangThai = "Chưa thanh toán"
                });
                cthdCtrl.Insert(new ChiTietHDB
                {
                    MaHDB = hdCtrl.GetAll().Count + 1,
                    MaSP = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_MaSP"].Value),
                    SoLuong = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_SoLuongb"].Value),
                    DonGia = Convert.ToDecimal(dgv_GioHang.Rows[0].Cells["col_DonGia"].Value),
                    MaKM = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_MaKM"].Value)
                });
            }
            else
            {
                hdCtrl.Insert(new HoaDon
                {
                    MaNV = _nv.MaNV,
                    MaKH = khCtrl.GetByPhone(txt_SDT.Text).MaKH,
                    NgayBan = DateTime.Now,
                    TienTamTinh = Convert.ToDecimal(txt_TamTinh.Text.Replace(",", "")),
                    TongTien = Convert.ToDecimal(txt_TongTien.Text.Replace(",", "")),
                    ChietKhau = Convert.ToDecimal(txt_ChietKhau.Text.Replace(",", "")),
                    ThueVAT = Convert.ToDecimal(txt_VAT.Text.Replace(",", "")),
                    TrangThai = "Chưa thanh toán"
                });
                cthdCtrl.Insert(new ChiTietHDB
                {
                    MaHDB = hdCtrl.GetAll().Count + 1,
                    MaSP = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_MaSP"].Value),
                    SoLuong = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_SoLuongb"].Value),
                    DonGia = Convert.ToDecimal(dgv_GioHang.Rows[0].Cells["col_DonGia"].Value),
                    MaKM = Convert.ToInt32(dgv_GioHang.Rows[0].Cells["col_MaKM"].Value)
                });
            }
            MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
