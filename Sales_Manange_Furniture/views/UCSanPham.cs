using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Sales_Manage_Furniture.controllers;
using Sales_Manage_Furniture.models;
using System.Reflection;

namespace Sales_Manange_Furniture.views
{
    public partial class UCSanPham : UserControl
    {
        SanPhamController spCtrl = new SanPhamController();
        public UCSanPham()
        {
            InitializeComponent();
        }
        private void UCSanPham_Load(object sender, EventArgs e)
        {
            // Xóa cột cũ
            dgv_SanPham.Columns.Clear();
            dgv_SanPham.Columns.Add("MaSPCol", "Mã SP");
            dgv_SanPham.Columns["MaSPCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột ảnh
            DataGridViewImageColumn colImg = new DataGridViewImageColumn();
            colImg.Name = "HinhAnhCol";
            colImg.HeaderText = "Ảnh";
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgv_SanPham.Columns.Add(colImg);

            
            // Cột tên sản phẩm
            dgv_SanPham.Columns.Add("TenSPCol", "Tên sản phẩm");
            dgv_SanPham.Columns["TenSPCol"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;

            // Cột giá
            dgv_SanPham.Columns.Add("GiaBanCol", "Giá bán");
            dgv_SanPham.Columns["GiaBanCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SanPham.Columns["GiaBanCol"].DefaultCellStyle.Format = "N0"; // Định dạng số với dấu phân cách hàng nghìn

            dgv_SanPham.Columns.Add("SoLuongCol","Số lượng");
            dgv_SanPham.Columns["SoLuongCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Lấy danh sách sản phẩm


            var listSanPham = spCtrl.Showdgv();
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName; 
            string imgFolder = Path.Combine(projectPath, "Sales_Manange_Furniture", "images", "product");
            // Gọi controller để load sản phẩm
            spCtrl.LoadSanPhamToGrid(dgv_SanPham, listSanPham, imgFolder);
        }



        private void dgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_SanPham_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy dòng hiện tại
            DataGridViewRow selectedRow = dgv_SanPham.Rows[e.RowIndex];
            // Lấy thông tin sản phẩm từ dòng
            int maSP = selectedRow.Cells["MaSPCol"].Value != null ? Convert.ToInt32(selectedRow.Cells["MaSPCol"].Value) : 0;
            SanPham sanPham = spCtrl.GetById(maSP);
            FSanPham f = new FSanPham(sanPham);
            f.ShowDialog();
        }
    }
}
