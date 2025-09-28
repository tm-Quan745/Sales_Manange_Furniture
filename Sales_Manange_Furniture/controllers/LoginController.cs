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
        public string USER_NAME = Session.USER_NAME;
        private DBConnect db = new DBConnect();

        // Hàm login: trả về "Admin" / "Employee" hoặc null nếu sai
        public string Login(string username, string password, string role)
        {
            
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDangNhap", username),
                new SqlParameter("@MatKhau", password),
                new SqlParameter("@Quyen", role)
            };

            DataTable dt = db.ExecuteQuery("sp_Login", parameters, CommandType.StoredProcedure);

            

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Quyen"].ToString();
            }
            return null;
        }

        

        // Lấy thông tin nhân viên theo username
        public NhanVien GetEmployee(string username)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDangNhap", username)
            };

            DataTable dt = db.ExecuteQuery("sp_GetEmployeeByUsername", parameters, CommandType.StoredProcedure);
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

        // ===== Hàm lấy SQL Login + Password =====
        public string GetSqlLogin(string username)
        {
          
            string query = "SELECT SqlLogin FROM TaiKhoan WHERE TenDangNhap = @username";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@username", username)
            };

            object result = db.ExecuteScalar(query, parameters, CommandType.Text);
            return result?.ToString();
        }


        public string GetSqlPass(string username)
        {

            string query = "SELECT SqlPass FROM TaiKhoan WHERE TenDangNhap = @username";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@username", username)
            };

            object result = db.ExecuteScalar(query, parameters, CommandType.Text);
            return result?.ToString();
        }


    }
}
