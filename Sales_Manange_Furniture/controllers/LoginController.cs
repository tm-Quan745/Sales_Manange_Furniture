using System;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.Models;
using Sales_Manange_Furniture.config;

namespace Sales_Manange_Furniture.Controllers
{
    internal class LoginController
    {
        private DBConnect db = new DBConnect();

        public TaiKhoan CheckLogin(string username, string password)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@user AND MatKhau=@pass";
            SqlParameter[] parameters =
            {
                new SqlParameter("@user", username),
                new SqlParameter("@pass", password)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                TaiKhoan tk = new TaiKhoan
                {
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    QuyenHan = row["QuyenHan"].ToString()
                };
                return tk; // đăng nhập thành công
            }
            return null; // đăng nhập thất bại
        }
    }
}
