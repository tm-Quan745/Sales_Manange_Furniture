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

namespace Sales_Manange_Furniture.views
{
    public partial class UCHoaDon : UserControl
    {
        HoaDonController hdCrl = new HoaDonController();
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
    }
}
