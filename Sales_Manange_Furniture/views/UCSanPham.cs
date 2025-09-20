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
    public partial class UCSanPham : UserControl
    {
        SanPhamController spCtrl = new SanPhamController();
        public UCSanPham()
        {
            InitializeComponent();
        }

        private void UCSanPham_Load(object sender, EventArgs e)
        {
            dgv_KhachHang.DataSource = spCtrl.GetAll();
        }
    }
}
