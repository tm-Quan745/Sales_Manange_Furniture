using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;

namespace Sales_Manage_Furniture.controllers
{
    internal class KhachHangController
    {
        DBConnect db;
        LoginController lgCtrl = new LoginController();

        public KhachHangController(string username)
        {
            string sqllogin = lgCtrl.GetSqlLogin(username);
            string sqlpass = lgCtrl.GetSqlPass(username);
            db = new DBConnect(sqllogin, sqlpass);
        }


        // Lấy tất cả khách hàng
        public List<KhachHang> GetAll()
        {
            string query = "sp_GetAllKhachHang";
            DataTable dt = db.ExecuteQuery(query);
            List<KhachHang> list = new List<KhachHang>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhachHang
                {
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    HoTen = row["HoTen"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                });
            }
            return list;
        }

        // Thêm khách hàng mới
        public bool Insert(KhachHang kh)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@diachi", kh.DiaChi),
                new SqlParameter("@SoDienThoai", kh.SoDienThoai),
                new SqlParameter("@email", kh.Email)
            };

            return db.ExecuteNonQuery("sp_InsertKhachHang", parameters, CommandType.StoredProcedure) > 0;
        }

        // Cập nhật khách hàng
        public bool Update(KhachHang kh)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ten", kh.HoTen),
                new SqlParameter("@diachi", kh.DiaChi),
                new SqlParameter("@sdt", kh.SoDienThoai),
                new SqlParameter("@email", kh.Email),
                new SqlParameter("@ma", kh.MaKH)
            };

            return db.ExecuteNonQuery("sp_UpdateKhachHang", parameters, CommandType.StoredProcedure) > 0;
        }

        // Xóa khách hàng
        public bool Delete(int maKH)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ma", maKH)
            };

            return db.ExecuteNonQuery("sp_DeleteKhachHang", parameters, CommandType.StoredProcedure) > 0;
        }
        public KhachHang GetByID(int id)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKH", id)
            };
            DataTable dt = db.ExecuteQuery("sp_GetKhachHangByID", parameters, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new KhachHang
                {
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    HoTen = row["HoTen"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                };
            }
            return null;
        }

        public KhachHang GetByPhone(string SDT)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@SoDienThoai", SDT)
            };
            DataTable dt = db.ExecuteQuery("sp_GetKhachHangByPhone", parameters, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new KhachHang
                {
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    HoTen = row["HoTen"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                };
            }
            return null;
        }

        // Tìm khách hàng theo tên, số điện thoại hoặc email
        public List<KhachHang> search(string keyword)
        {
            
            SqlParameter[] parameters =
            {
            new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = db.ExecuteQuery("sp_SearchKhachHang", parameters, CommandType.StoredProcedure);
            List<KhachHang> list = new List<KhachHang>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhachHang
                {
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    HoTen = row["HoTen"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return list;
        }

    }
}
