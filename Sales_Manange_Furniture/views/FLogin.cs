using System;
using System.Windows.Forms;
using Sales_Manage_Furniture;

namespace Sales_Manage_Furniture
{
   
    public partial class FLogin : Form
    {
        //public static EmployeeModel  userLogin = new EmployeeModel();
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            //txt_username.Focus();
        }

        private void phide_Click(object sender, EventArgs e)
        {
            //if (txt_passwd.PasswordChar == '*')
            //{
            //    pshow.BringToFront();
            //    txt_passwd.PasswordChar = '\0';
            //}

        }
        private void pshow_Click(object sender, EventArgs e)
        {
            //if (txt_passwd.PasswordChar == '\0')
            //{
            //    phide.BringToFront();
            //    txt_passwd.PasswordChar = '*';
            //}   
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //// Lấy username + password
            //string username = txt_username.Text.Trim();
            //string password = txt_passwd.Text.Trim();

            //// Kiểm tra role chọn từ RadioButton
            //string role = rbtn_admin.Checked ? "Admin" : "Employee";

            //// Kiểm tra input
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ Username và Password.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Gọi Controller xử lý login
            //var uclogin_control = new LoginController();
            //string loginRole = uclogin_control.Login(username, password, role);

            //if (loginRole != null) // Đăng nhập thành công
            //{
            //    if (loginRole == "Employee")
            //    {
            //        // Kiểm tra trạng thái nhân viên
            //        if (!uclogin_control.CheckActive(username))
            //        {
            //            MessageBox.Show("Tài khoản này đã bị khóa. Vui lòng liên hệ Admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        txt_username.Clear();
            //        txt_passwd.Clear();

            //        // Lấy thông tin nhân viên đăng nhập
            //        userLogin = uclogin_control.GetEmployee(username);

            //        // Mở form dành cho nhân viên
            //        this.Hide();
            //        var fEmployee = new FControl();
            //        fEmployee.Show();

            //        fEmployee.FormClosed += (s, args) => Application.Exit();
            //    }
            //    else if (loginRole == "Admin")
            //    {
            //        txt_username.Clear();
            //        txt_passwd.Clear();
            //        userLogin.Name = "Admin";

            //        // Mở form dành cho admin
            //        this.Hide();
            //        var fManager = new FManager();
            //        fManager.Show();

            //        fManager.FormClosed += (s, args) => Application.Exit();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Sai Username hoặc Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        

        private void FLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
