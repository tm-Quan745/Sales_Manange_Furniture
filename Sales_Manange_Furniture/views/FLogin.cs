using System;
using System.Windows.Forms;

using Sales_Manage_Furniture.controllers;
using Sales_Manage_Furniture.models;
using Sales_Manange_Furniture.views;

namespace Sales_Manage_Furniture.views
{
   
    public partial class FLogin : Form
    {
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
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi Controller xử lý login
            var login_control = new LoginController();
            string loginRole = login_control.Login(username, password, role);

            if (loginRole != null) // ✅ Đăng nhập thành công
            {

                // Lấy thông tin nhân viên đăng nhập
                var userLogin = login_control.GetEmployee(username);
                Session.MaNV = userLogin.MaNV;
                Session.USER_NAME = username;
                Session.Role = loginRole;
                // Xóa ô nhập
                txt_username.Clear();
                txt_passwd.Clear();

                // Ẩn form login
                this.Hide();

                Form nextForm = null;

                // ✅ Kiểm tra vai trò và mở form tương ứng
                if (loginRole == "Admin")
                {
                    nextForm = new FQuanLy(userLogin);
                }
                else if (loginRole == "NhanVien")
                {
                    nextForm = new FNhanVien(userLogin);
                }

                if (nextForm != null)
                {
                    // Khi form chính đóng -> quay lại form login
                    nextForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                        this.txt_username.Focus();
                    };

                    nextForm.Show();
                }
                else
                {
                    MessageBox.Show("Không xác định được vai trò người dùng!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai Username hoặc Password.",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
