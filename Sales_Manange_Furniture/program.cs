using System;
using System.Windows.Forms;
using Sales_Manage_Furniture.views;
using Sales_Manange_Furniture.views;

namespace Sales_Manage_Furniture
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo form login
            var loginForm = new FLogin();

            // Khi form login bị đóng (nhấn X) thì thoát app
            loginForm.FormClosed += (s, e) => Application.Exit();

            // Chạy form login
            Application.Run(loginForm);
        }
    }
}
