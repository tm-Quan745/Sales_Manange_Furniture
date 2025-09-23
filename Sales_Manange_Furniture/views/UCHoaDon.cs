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
    public partial class UCHoaDon : UserControl
    {
        HoaDonController hdCrl = new HoaDonController();
        ChiTietHDBController ctCrl = new ChiTietHDBController();
        public UCHoaDon()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void UCHoaDon_Load(object sender, EventArgs e)
        {
            dgv_HoaDon.DataSource = hdCrl.GetAll();

        }

        private void dgv_HoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_HoaDon.Rows[e.RowIndex];
            // Lấy thông tin sản phẩm từ dòng
            int maHD = selectedRow.Cells["col_MaHDB"].Value != null ? Convert.ToInt32(selectedRow.Cells["col_MaHDB"].Value) : 0;
            HoaDon hoaDon = hdCrl.GetById(maHD);
            List<ChiTietHDB> chiTiet = ctCrl.GetByHoaDon(maHD);
            FHoaDon f = new FHoaDon(hoaDon,chiTiet);
            f.ShowDialog();
        }
    }
}
