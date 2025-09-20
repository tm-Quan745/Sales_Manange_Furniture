using System;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;

namespace Sales_Manage_Furniture.controllers
{
    public class LoginController
    {
        private DBConnect db = new DBConnect();

        // Hàm login: trả về "Admin" / "Employee" hoặc null nếu sai
        public string Login(string username, string password, string role)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@user AND MatKhau=@pass AND Quyen=@role";
            SqlParameter[] parameters =
            {
                new SqlParameter("@user", username),
                new SqlParameter("@pass", password),
                new SqlParameter("@role", role)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Quyen"].ToString();
            }
            return null;
        }

        

        // Lấy thông tin nhân viên theo username
        public NhanVien GetEmployee(string username)
        {
            string query = @"SELECT nv.* 
                             FROM NhanVien nv
                             INNER JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                             WHERE tk.TenDangNhap=@user";
            SqlParameter[] parameters =
            {
                new SqlParameter("@user", username)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new NhanVien
                {
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    HoTen = row["HoTen"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    ChucVu = row["ChucVu"].ToString()
                };
            }
            return null;
        }
    }
}
