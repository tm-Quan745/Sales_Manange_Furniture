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

namespace Sales_Manange_Furniture.views
{
    public partial class FNhanVien : Form
    {
        private Guna2Button currentButton = null; // Lưu button đang được chọn
        private Color defaultColor = Color.FromArgb(53, 74, 98); // Màu mặc định
        private Color activeColor = ColorTranslator.FromHtml("#99B4D1"); // Màu hover/active

        public FNhanVien()
        {
            InitializeComponent();
        }

        private void pnl_Main_Paint(object sender, PaintEventArgs e)
        {
        }

        // Hàm load UserControl vào panel
        private void LoadTab(UserControl uc)
        {
            pnl_Main.Controls.Clear();   // Xóa control cũ
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

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            LoadTab(new UCThongKe());
            ActivateButton(btn_ThongKe);
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
    }
}
