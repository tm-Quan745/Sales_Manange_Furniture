using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;


namespace Sales_Manage_Furniture.controllers
{
    internal class HoaDonController
    {
        private DBConnect db = new DBConnect();

        // Lấy tất cả hóa đơn
        public List<HoaDon> GetAll()
        {
            string query = "SELECT * FROM HoaDonBan";   // đúng tên bảng
            DataTable dt = db.ExecuteQuery(query);
            List<HoaDon> list = new List<HoaDon>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HoaDon
                {
                    MaHDB = Convert.ToInt32(row["MaHDB"]),
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    NgayBan = Convert.ToDateTime(row["NgayBan"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = row["TrangThai"].ToString()
                });
            }
            return list;
        }

        // Thêm hóa đơn mới
        public bool Insert(HoaDon hd)
        {
            string query = @"INSERT INTO HoaDonBan(MaKH, MaNV, NgayBan, TongTien, TrangThai) 
                             VALUES (@makh, @manv, @ngayban, @tongtien, @trangthai)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@makh", hd.MaKH),
                new SqlParameter("@manv", hd.MaNV),
                new SqlParameter("@ngayban", hd.NgayBan),
                new SqlParameter("@tongtien", hd.TongTien),
                new SqlParameter("@trangthai", hd.TrangThai)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật hóa đơn
        public bool Update(HoaDon hd)
        {
            string query = @"UPDATE HoaDonBan 
                             SET MaKH=@makh, MaNV=@manv, NgayBan=@ngayban, TongTien=@tongtien, TrangThai=@trangthai
                             WHERE MaHDB=@mahdb";
            SqlParameter[] parameters =
            {
                new SqlParameter("@makh", hd.MaKH),
                new SqlParameter("@manv", hd.MaNV),
                new SqlParameter("@ngayban", hd.NgayBan),
                new SqlParameter("@tongtien", hd.TongTien),
                new SqlParameter("@trangthai", hd.TrangThai),
                new SqlParameter("@mahdb", hd.MaHDB)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa hóa đơn
        public bool Delete(int maHDB)
        {
            string query = "DELETE FROM HoaDonBan WHERE MaHDB=@mahdb";
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", maHDB)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
