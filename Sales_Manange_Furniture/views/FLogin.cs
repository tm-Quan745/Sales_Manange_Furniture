using System;
using System.Windows.Forms;

using Sales_Manage_Furniture.controllers;
using Sales_Manage_Furniture.models;
using Sales_Manange_Furniture.views;

namespace Sales_Manage_Furniture.views
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
            txt_username.Focus();
        }

        private void phide_Click(object sender, EventArgs e)
        {
            if (txt_passwd.PasswordChar == '*')
            {
                pshow.BringToFront();
                txt_passwd.PasswordChar = '\0';
            }

        }
        private void pshow_Click(object sender, EventArgs e)
        {
            if (txt_passwd.PasswordChar == '\0')
            {
                phide.BringToFront();
                txt_passwd.PasswordChar = '*';
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Lấy username + password
            string username = txt_username.Text.Trim();
            string password = txt_passwd.Text.Trim();

            // Kiểm tra role chọn từ RadioButton
            string role = rbtn_QuanLy.Checked ? "Admin" : "NhanVien";

            // Kiểm tra input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi Controller xử lý login
            var login_control = new LoginController();
            string loginRole = login_control.Login(username, password, role);
            var userLogin = new NhanVien();
            if (loginRole != null) // Đăng nhập thành công
            {
                if (loginRole == "NhanVien")
                {

                    txt_username.Clear();
                    txt_passwd.Clear();

                    // Lấy thông tin nhân viên đăng nhập
                    userLogin = login_control.GetEmployee(username);

                    // Mở form dành cho nhân viên
                    this.Hide();
                    var fEmployee = new FNhanVien(userLogin);
                    fEmployee.Show();

                    fEmployee.FormClosed += (s, args) => Application.Exit();
                }
                else if (loginRole == "Admin")
                {
                    txt_username.Clear();
                    txt_passwd.Clear();
                    userLogin = login_control.GetEmployee(username);

                    // Mở form dành cho admin
                    this.Hide();
                    var fManager = new FQuanLy(userLogin);
                    fManager.Show();

                    fManager.FormClosed += (s, args) => Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Sai Username hoặc Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void FLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
