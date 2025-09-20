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
        private DBConnect db = new DBConnect();

        // Lấy tất cả khách hàng
        public List<KhachHang> GetAll()
        {
            string query = "SELECT * FROM KhachHang";
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

        // Tìm khách hàng theo tên hoặc SĐT
        public List<KhachHang> Search(string keyword)
        {
            string query = "SELECT * FROM KhachHang WHERE HoTen LIKE @kw OR SoDienThoai LIKE @kw";
            SqlParameter[] parameters =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
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
            string query = "INSERT INTO KhachHang (HoTen, DiaChi, SoDienThoai, Email) VALUES (@ten, @diachi, @sdt, @email)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ten", kh.HoTen),
                new SqlParameter("@diachi", kh.DiaChi),
                new SqlParameter("@sdt", kh.SoDienThoai),
                new SqlParameter("@email", kh.Email)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật khách hàng
        public bool Update(KhachHang kh)
        {
            string query = "UPDATE KhachHang SET HoTen=@ten, DiaChi=@diachi, SoDienThoai=@sdt, Email=@email WHERE MaKH=@ma";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ten", kh.HoTen),
                new SqlParameter("@diachi", kh.DiaChi),
                new SqlParameter("@sdt", kh.SoDienThoai),
                new SqlParameter("@email", kh.Email),
                new SqlParameter("@ma", kh.MaKH)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa khách hàng
        public bool Delete(int maKH)
        {
            string query = "DELETE FROM KhachHang WHERE MaKH=@ma";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ma", maKH)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
