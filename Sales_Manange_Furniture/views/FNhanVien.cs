using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms; // Thêm namespace Guna2Button
using Sales_Manage_Furniture.views;
using Sales_Manange_Furniture.views;
namespace Sales_Manage_Furniture.views
{
    public partial class FNhanVien : Form
    {
        private Guna2Button currentButton = null; // Lưu button đang được chọn
        private Color defaultColor = Color.FromArgb(53, 74, 98); // Màu mặc định
        private Color activeColor = ColorTranslator.FromHtml("#99B4D1"); // Màu hover/active
        private string _Hoten;

        public FNhanVien()
        {
            InitializeComponent();
        }
        public FNhanVien(string Hoten) // <-- constructor mới
        {
            InitializeComponent();
            _Hoten = Hoten;
        }
        private void pnl_Main_Paint(object sender, PaintEventArgs e)
        {
        }

        // Hàm load UserControl vào panel
        private void LoadTab(UserControl uc)
        {
            pnl_Main.Controls.Clear();   // Xóa control cũ
            pnl_Main.Padding = new Padding(25, 0, 0, 0); // chừa khoảng trống 10px bên trái
            uc.Dock = DockStyle.Fill;    // Fill toàn bộ Panel
            pnl_Main.Controls.Add(uc);   // Thêm UC mới
        }

        // Hàm active button
        private void ActivateButton(Guna2Button btn)
        {
            if (currentButton != null)
            {
                // Reset màu nút cũ
                currentButton.FillColor = defaultColor;
            }

            // Chọn nút mới
            currentButton = btn;
            currentButton.FillColor = activeColor;
        }

        // Các sự kiện click
        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            LoadTab(new UCBanHang());
            ActivateButton(btn_BanHang);
        }


        private void Btn_KhachHang_Click(object sender, EventArgs e)
        {
            LoadTab(new UCKhachHang());
            ActivateButton(Btn_KhachHang);
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            LoadTab(new UCSanPham());
            ActivateButton(btn_SanPham);
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            LoadTab(new UCHoaDon());
            ActivateButton(btn_HoaDon);
        }

        // Khi form load -> mặc định chọn Bán Hàng
        private void FControl_Load(object sender, EventArgs e)
        {
            btn_BanHang.PerformClick();
        }

        private void pnl_Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_Topbar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FLogin login = new FLogin();
                login.ShowDialog();
                this.Close();
            }
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            txt_Ten.Text = _Hoten;
        }
    }
}

