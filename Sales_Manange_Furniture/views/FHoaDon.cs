using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manage_Furniture.controllers;
using Sales_Manage_Furniture.models;

namespace Sales_Manange_Furniture.views
{
    public partial class FHoaDon : Form
    {
        KhachHangController khCtrl = new KhachHangController();
        HoaDon _hd = new HoaDon();
        List<ChiTietHDB> _ct = new List<ChiTietHDB>();
        KhachHang KhachHang = new KhachHang();
        public FHoaDon()
        {
            InitializeComponent();
        }
        public FHoaDon(HoaDon hd,List<ChiTietHDB> ct)
        {
            InitializeComponent();
            _hd = hd;
            _ct = ct;
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(_hd.MaKH);
            var kh = khCtrl.GetByID(maKH);

            if (kh != null)
            {
                txt_DiaChi.Text = kh.DiaChi;
                txt_Email.Text = kh.Email;
                txt_TenKH.Text = kh.HoTen;
                txt_SDT.Text = kh.SoDienThoai;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load chi tiết hóa đơn
            dgv_ChiTietHD.AutoGenerateColumns = false;
            dgv_ChiTietHD.DataSource = _ct;
            txt_TamTinh.Text = $"{ _hd.TienTamTinh.ToString("N0")} VND";
            txt_ChietKhau.Text = $"- {_hd.ChietKhau.ToString("N0")} VND";
            txt_Vat.Text = $"+ {_hd.ThueVAT.ToString("N0")} VND";
            txt_TongTien.Text = $"{_hd.TongTien.ToString("N0")} VND";



        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_TamTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {

        }

        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_TongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
