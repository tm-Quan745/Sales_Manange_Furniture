using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manage_Furniture.models;

namespace Sales_Manange_Furniture.views
{
    public partial class FSanPham : Form
    {
        SanPham _sp = new SanPham();
        public FSanPham()
        {
            InitializeComponent();
        }
        public FSanPham(SanPham sp)
        {
            InitializeComponent();
            _sp = sp;

        }

        private void FSanPhamcs_Load(object sender, EventArgs e)
        {
            txt_TenSP.Text = _sp.TenSP;
            txt_Gia.Text = $"{_sp.GiaBan.ToString("N0")} VND";
            txt_SoLuong.Text = _sp.SoLuongTon.ToString();
            // 👉 Ghép đường dẫn ảnh đầy đủ
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string imgFolder = Path.Combine(projectPath, "Sales_Manange_Furniture", "images", "product");
            string imgPath = Path.Combine(imgFolder, _sp.HinhAnh);

            if (!string.IsNullOrEmpty(_sp.HinhAnh) && File.Exists(imgPath))
            {
                pic_SP.SizeMode = PictureBoxSizeMode.Zoom;
                pic_SP.Image = Image.FromFile(imgPath);
            }
            txt_MoTa.Text = _sp.MoTa;
            txt_DonVi.Text = _sp.DonViTinh;
            txt_MaSP.Text = _sp.MaSP.ToString();
        }

        private void txt_TenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void pic_SP_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
