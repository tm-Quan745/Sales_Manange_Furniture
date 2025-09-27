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
        private void UCHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
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

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string input = txt_Tim.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn hoặc thông tin khách hàng cần tìm!");
                return;
            }

            List<HoaDon> result = new List<HoaDon>();

            if (int.TryParse(input, out int maHD))
            {
                HoaDon hd = hdCrl.Search(maHD); // tìm theo ID
                if (hd != null) result.Add(hd);
            }
            else
            {
                result = hdCrl.Search(input); // tìm theo chuỗi
            }

            dgv_HoaDon.DataSource = result.Count > 0 ? result : null;

            if (result.Count == 0)
                MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp!");
        }




        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_Tim.Clear();
        }
    }
}
