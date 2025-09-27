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
using Sales_Manange_Furniture.ADO.QuanLyNoiThatDataSetTableAdapters;
using Sales_Manange_Furniture.views;
using Sales_Manage_Furniture.models;
namespace Sales_Manage_Furniture.views
{
    public partial class FNhanVien : Form
    {
        private Guna2Button currentButton = null;
        private Color defaultColor = Color.FromArgb(53, 74, 98);
        private Color activeColor = ColorTranslator.FromHtml("#99B4D1");
        public NhanVien _nv;

        // --- giữ các instance UserControl ---
        private UCBanHang ucBanHang;
        private UCKhachHang ucKhachHang;
        private UCSanPham ucSanPham;
        private UCHoaDon ucHoaDon;

        public FNhanVien()
        {
            InitializeComponent();
        }

        public FNhanVien(NhanVien nv)
        {
            InitializeComponent();
            _nv = nv;
        }

        private void LoadTab(UserControl uc)
        {
            // Ẩn tất cả control trong panel
            foreach (Control c in pnl_Main.Controls)
                c.Hide();

            // Nếu control chưa có trong panel thì thêm
            if (!pnl_Main.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnl_Main.Padding = new Padding(25, 0, 0, 0);
                pnl_Main.Controls.Add(uc);
            }

            // Hiển thị lên
            uc.Show();
            uc.BringToFront();
        }

        private void ActivateButton(Guna2Button btn)
        {
            if (currentButton != null)
                currentButton.FillColor = defaultColor;

            currentButton = btn;
            currentButton.FillColor = activeColor;
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            if (ucBanHang == null) ucBanHang = new UCBanHang(_nv);
            LoadTab(ucBanHang);
            ActivateButton(btn_BanHang);
        }

        private void Btn_KhachHang_Click(object sender, EventArgs e)
        {
            if (ucKhachHang == null) ucKhachHang = new UCKhachHang();
            LoadTab(ucKhachHang);
            ActivateButton(Btn_KhachHang);
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            if (ucSanPham == null) ucSanPham = new UCSanPham();
            LoadTab(ucSanPham);
            ActivateButton(btn_SanPham);
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            if (ucHoaDon == null) ucHoaDon = new UCHoaDon();
            LoadTab(ucHoaDon);
            ActivateButton(btn_HoaDon);
        }

        private void FControl_Load(object sender, EventArgs e)
        {
            btn_BanHang.PerformClick();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            txt_Ten.Text = _nv.HoTen.ToString();
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

        public void ChuyenSangTabGioHang()
        {
            if (ucBanHang == null) ucBanHang = new UCBanHang(_nv);
            LoadTab(ucBanHang);
            ActivateButton(btn_BanHang);
        }
    }

}


