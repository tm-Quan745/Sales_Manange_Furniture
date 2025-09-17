using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manage_Furniture;

namespace Sales_Manage_Furniture
{
    public partial class FWelcome : Form
    {
        public FWelcome()
        {
            InitializeComponent();
        }

        private void FWelcome_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn FormA

            var flogin = new FLogin();
            flogin.Show();

            flogin.FormClosed += (s, args) =>
            {
                // Khi formB đóng thì thoát chương trình
                Application.Exit();
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
