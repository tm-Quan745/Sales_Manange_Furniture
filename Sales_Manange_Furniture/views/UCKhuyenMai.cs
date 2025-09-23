using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manange_Furniture.controllers;
using Sales_Manage_Furniture.models;
using Sales_Manange_Furniture.models;

namespace Sales_Manange_Furniture.views
{
    public partial class UCKhuyenMai : UserControl
    {
        KhuyenMaiController kmCtrl = new KhuyenMaiController();
        ChiTietKhuyenMaiController ctkmCtrl = new ChiTietKhuyenMaiController();
        public UCKhuyenMai()
        {
            InitializeComponent();
        }

        private void tp_KhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCKhuyenMai_Load(object sender, EventArgs e)
        {
            List<KhuyenMai> km = kmCtrl.GetAll();
            dgv_KhuyenMai.DataSource = km;
            List<ChiTietKhuyenMai> ctkm = ctkmCtrl.GetAll();
            dgv_ChiTietKhuyenMai.DataSource = ctkm;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void txt_Tim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
