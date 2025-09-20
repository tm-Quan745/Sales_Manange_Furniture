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
            var list = khCtrl.GetAll();
            dgv_KhachHang.DataSource = list;
        }
    }
}
