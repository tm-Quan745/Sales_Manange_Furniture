using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales_Manage_Furniture.controllers;
using System.Windows.Forms;

namespace Sales_Manange_Furniture.views
{
    public partial class FThanhToan : Form
    {
        string _TongTien = "";
        int _maHD = 0;
        HoaDonController hdCtrl;
        LoginController lgCtrl = new LoginController();
        public FThanhToan(int maHD, string TongTien)
        {
            InitializeComponent();
            _TongTien = TongTien;
            _maHD = maHD;
            hdCtrl = new HoaDonController(lgCtrl.USER_NAME);
        }

        private void FThanhToan_Load(object sender, EventArgs e)
        {
            lbl_TongTien.Text = _TongTien;

        }

        private void txt_TienKhachDua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển (Backspace, Delete, mũi tên, v.v.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txt_TienKhachDua_Leave(object sender, EventArgs e)
        {
            // ✅ Nếu người dùng không nhập gì -> mặc định 0
            if (string.IsNullOrWhiteSpace(txt_TienKhachDua.Text))
            {
                txt_TienKhachDua.Text = "0";
            }

            // ✅ Chuyển text sang số
            if (decimal.TryParse(txt_TienKhachDua.Text, out decimal tienKhachDua))
            {
                // Format kiểu N0 (1,000,000)
                txt_TienKhachDua.Text = tienKhachDua.ToString("N0");

                // ✅ Lấy tổng tiền từ label (bỏ dấu phẩy)
                string tongTienText = lbl_TongTien.Text.Replace(",", "").Trim();
                decimal tongTien = 0;

                decimal.TryParse(tongTienText, out tongTien);

                // ✅ Kiểm tra điều kiện
                if (tienKhachDua < tongTien)
                {
                    MessageBox.Show("Số tiền khách đưa phải lớn hơn hoặc bằng tổng tiền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TienKhachDua.Focus();
                    txt_TienThua.Text = "0";
                    return;
                }

                // ✅ Tính tiền thừa
                decimal tienThua = tienKhachDua - tongTien;
                txt_TienThua.Text = tienThua.ToString("N0");
            }
            else
            {
                MessageBox.Show("Giá trị nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TienKhachDua.Text = "0";
                txt_TienThua.Text = "0";
            }

        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra tiền khách đưa
                if (string.IsNullOrWhiteSpace(txt_TienKhachDua.Text) || txt_TienKhachDua.Text == "0")
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TienKhachDua.Focus();
                    return;
                }

                // Lấy tổng tiền cần thanh toán
                decimal tongTien = decimal.Parse(lbl_TongTien.Text.Replace(",", "").Trim());
                decimal tienKhachDua = decimal.Parse(txt_TienKhachDua.Text.Replace(",", "").Trim());

                // Kiểm tra nếu tiền khách đưa nhỏ hơn tổng tiền
                if (tienKhachDua < tongTien)
                {
                    MessageBox.Show("Số tiền khách đưa không đủ để thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TienKhachDua.Focus();
                    return;
                }

                // ✅ Cập nhật trạng thái hóa đơn
                hdCtrl.UpdateTrangThaiHD(_maHD, "Đã thanh toán");

                // Tính tiền thừa và hiển thị (không có ký hiệu ₫)
                decimal tienThua = tienKhachDua - tongTien;
                txt_TienThua.Text = tienThua.ToString("N0");

                MessageBox.Show("💰 Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
