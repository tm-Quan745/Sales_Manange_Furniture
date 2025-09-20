using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Sales_Manange_Furniture.views
{
    public partial class FQuanLy : Form
    {
        private Guna2Button currentButton = null; // Lưu button đang được chọn
        private Color defaultColor = Color.FromArgb(53, 74, 98); // Màu mặc định
        private Color activeColor = ColorTranslator.FromHtml("#99B4D1"); // Màu hover/active
        public FQuanLy()
        {
            InitializeComponent();
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


        private void FQuanLy_Load(object sender, EventArgs e)
        {
            
        }

        private void pnl_Topbar_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pnl_Main_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {

            LoadTab(new UCKhuyenMai());
            ActivateButton(btn_KhuyenMai);

        }

        private void btn_KhuyenMai_Click(object sender, EventArgs e)
        {
            LoadTab(new UCKhuyenMai());
            ActivateButton(btn_KhuyenMai);
        }

        private void btn_Thongke_Click_1(object sender, EventArgs e)
        {
            LoadTab(new UCThongKe());
            ActivateButton(btn_ThongKe);
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            LoadTab(new UCBanHang());
            ActivateButton(btn_BanHang);
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            LoadTab(new UCHoaDon());
            ActivateButton(btn_HoaDon);
        }
    }
}
