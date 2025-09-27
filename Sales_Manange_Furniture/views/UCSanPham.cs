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
using Sales_Manage_Furniture.views;

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
            LoadData();
        }
        
        private void LoadData()
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
            dgv_SanPham.Columns["TenSPCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột giá
            dgv_SanPham.Columns.Add("GiaBanCol", "Giá bán");
            dgv_SanPham.Columns["GiaBanCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SanPham.Columns["GiaBanCol"].DefaultCellStyle.Format = "N0"; // Định dạng số với dấu phân cách hàng nghìn

            dgv_SanPham.Columns.Add("SoLuongCol", "Số lượng");
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_SanPham.Rows[e.RowIndex];
                int maSP = selectedRow.Cells["MaSPCol"].Value != null ? Convert.ToInt32(selectedRow.Cells["MaSPCol"].Value) : 0;

                SanPham sanPham = spCtrl.GetById(maSP);
                using (FSanPham f = new FSanPham(sanPham))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        // Form con trả về OK -> gọi cha FNhanVien để chuyển tab
                        FNhanVien parentForm = this.FindForm() as FNhanVien;
                        if (parentForm != null)
                        {
                            
                            parentForm.ChuyenSangTabGioHang();
                        }
                    }
                }
            }
        }


        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string input = txt_Tim.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập tên, mã hoặc mô tả sản phẩm cần tìm!");
                return;
            }

            List<SanPham> result = spCtrl.Search(input); // Search theo tên

            // Xóa dữ liệu cũ
            dgv_SanPham.Rows.Clear();

            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string imgFolder = Path.Combine(projectPath, "Sales_Manange_Furniture", "images", "product");

            if (result.Count > 0)
            {
                spCtrl.LoadSanPhamToGrid(dgv_SanPham, result, imgFolder);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!");
            }
        }



        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_Tim.Clear();
        }
    }
}
