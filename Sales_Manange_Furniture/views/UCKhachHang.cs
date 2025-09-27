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
using Sales_Manage_Furniture.controllers;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.views;

namespace Sales_Manange_Furniture.views
{
    public partial class UCKhachHang : UserControl
    {
        KhachHangController khCtrl = new KhachHangController();
        public UCKhachHang()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Form f = new FAddKhachHangcs();
            f.ShowDialog();
        }

        private void txt_Tim_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgv_KhachHang.DataSource = khCtrl.GetAll();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string input = txt_Tim.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập tên, số điện thoại hoặc email khách hàng cần tìm!");
                return;
            }

            List<KhachHang> result = khCtrl.Search(input); // Search theo tên, SĐT, Email

            dgv_KhachHang.DataSource = result.Count > 0 ? result : null;

            if (result.Count == 0)
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp!");
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_Tim.Clear();
        }
    }
}
