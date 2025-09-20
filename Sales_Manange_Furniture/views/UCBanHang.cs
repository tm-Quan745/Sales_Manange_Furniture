using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Manange_Furniture.views
{
    public partial class UCBanHang : UserControl
    {
        public UCBanHang()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCBanHang_Load(object sender, EventArgs e)
        {

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
    }
}
