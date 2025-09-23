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
using Sales_Manage_Furniture.controllers;

namespace Sales_Manange_Furniture.views
{
    public partial class UCBanHang : UserControl
    {
        SanPhamController spCtrl = new SanPhamController();
        public UCBanHang()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCBanHang_Load(object sender, EventArgs e)
        {
            // Xóa cột cũ
            dgv_SanPham2.Columns.Clear();
            dgv_SanPham2.Columns.Add("MaSPCol", "Mã SP");
            dgv_SanPham2.Columns["MaSPCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột ảnh
            DataGridViewImageColumn colImg = new DataGridViewImageColumn();
            colImg.Name = "HinhAnhCol";
            colImg.HeaderText = "Ảnh";
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgv_SanPham2.Columns.Add(colImg);


            // Cột tên sản phẩm
            dgv_SanPham2.Columns.Add("TenSPCol", "Tên sản phẩm");
            dgv_SanPham2.Columns["TenSPCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột giá
            dgv_SanPham2.Columns.Add("GiaBanCol", "Giá bán");
            dgv_SanPham2.Columns["GiaBanCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SanPham2.Columns["GiaBanCol"].DefaultCellStyle.Format = "N0"; // Định dạng số với dấu phân cách hàng nghìn

            dgv_SanPham2.Columns.Add("SoLuongCol", "Số lượng");
            dgv_SanPham2.Columns["SoLuongCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Lấy danh sách sản phẩm
            var listSanPham = spCtrl.Showdgv();

            // Đường dẫn thư mục ảnh
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string imgFolder = Path.Combine(projectPath, "Sales_Manange_Furniture", "images", "product");

            // Gọi controller để load sản phẩm
            spCtrl.LoadSanPhamToGrid(dgv_SanPham2, listSanPham, imgFolder);
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            // 4. Hiện thông báo
            MessageBox.Show("Đơn hàng đã được lưu thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Mở form Hóa đơn để xem/ in
            FHoaDon f = new FHoaDon(); // truyền mã hóa đơn qua constructor
            f.ShowDialog();
        }

        private void dgv_SanPham2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
