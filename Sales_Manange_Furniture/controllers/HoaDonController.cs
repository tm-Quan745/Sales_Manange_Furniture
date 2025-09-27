using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
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
            string query = "SELECT * FROM HoaDonBan";

            ;
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
                    TienTamTinh = Convert.ToDecimal(row["TienTamTinh"]),
                    ChietKhau = Convert.ToDecimal(row["ChietKhau"]),
                    ThueVAT = Convert.ToDecimal(row["ThueVAT"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = row["TrangThai"].ToString()

                });
            }
            return list;
        }

        // Thêm hóa đơn mới
        public bool Insert(HoaDon hd)
        {
            string query = @"INSERT INTO HoaDonBan(MaKH, MaNV, NgayBan, TienTamTinh, ThueVAT, ChietKhau, TongTien, TrangThai) 
                             VALUES (@makh, @manv, @ngayban, @TienTamTinh, @vat, @chietkhau, @tongtien, @trangthai)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@makh", hd.MaKH),
                new SqlParameter("@manv", hd.MaNV),
                new SqlParameter("@ngayban", hd.NgayBan),
                new SqlParameter("@TienTamTinh", hd.TienTamTinh),
                new SqlParameter("@vat", hd.ThueVAT),
                new SqlParameter("@chietkhau", hd.ChietKhau),
                new SqlParameter("@tongtien", hd.TongTien),
                new SqlParameter("@trangthai", hd.TrangThai)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật hóa đơn
        public bool Update(HoaDon hd)
        {
            string query = @"UPDATE HoaDonBan 
                             SET MaKH=@makh, MaNV=@manv, NgayBan=@ngayban,
                                 TienTamTinh=@TienTamTinh, ThueVAT=@vat, MaKM=@MaKM, TongTien=@tongtien, TrangThai=@trangthai
                             WHERE MaHDB=@mahdb";
            SqlParameter[] parameters =
            {
                new SqlParameter("@makh", hd.MaKH),
                new SqlParameter("@manv", hd.MaNV),
                new SqlParameter("@ngayban", hd.NgayBan),
                new SqlParameter("@TienTamTinh", hd.TienTamTinh),
                new SqlParameter("@vat", hd.ThueVAT),
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

        // Lấy hóa đơn theo ID
        public HoaDon GetById(int maHDB)
        {
            string query = "SELECT * FROM HoaDonBan WHERE MaHDB=@mahdb";
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", maHDB)
            };
            DataTable dt = db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new HoaDon
                {
                    MaHDB = Convert.ToInt32(row["MaHDB"]),
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    NgayBan = Convert.ToDateTime(row["NgayBan"]),
                    TienTamTinh = Convert.ToDecimal(row["TienTamTinh"]),
                    ChietKhau = Convert.ToDecimal(row["ChietKhau"]),
                    ThueVAT = Convert.ToDecimal(row["ThueVAT"]),
                    
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = row["TrangThai"].ToString()
                };
            }
            return null;
        }


      
        // Tìm hóa đơn theo tên KH, số điện thoại hoặc email
        // Tìm hóa đơn theo mã hóa đơn
        public HoaDon Search(int maHDB)
        {
            string query = @"SELECT * FROM HoaDonBan WHERE MaHDB = @mahdb";

            SqlParameter[] parameters =
            {
        new SqlParameter("@mahdb", maHDB)
    };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new HoaDon
                {
                    MaHDB = Convert.ToInt32(row["MaHDB"]),
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    NgayBan = Convert.ToDateTime(row["NgayBan"]),
                    TienTamTinh = Convert.ToDecimal(row["TienTamTinh"]),
                    ChietKhau = row.Table.Columns.Contains("ChietKhau") ? Convert.ToDecimal(row["ChietKhau"]) : 0,
                    ThueVAT = Convert.ToDecimal(row["ThueVAT"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }
        public List<HoaDon> Search(string keyword)
        {
            string query = @"
            SELECT hd.* 
            FROM HoaDonBan hd
            INNER JOIN KhachHang kh ON hd.MaKH = kh.MaKH
            WHERE kh.TenKH LIKE @keyword 
               OR kh.SDT LIKE @keyword 
               OR kh.Email LIKE @keyword";

            SqlParameter[] parameters =
            {
        new SqlParameter("@keyword", "%" + keyword + "%")
    };

            DataTable dt = db.ExecuteQuery(query, parameters);

            List<HoaDon> result = new List<HoaDon>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new HoaDon
                {
                    MaHDB = Convert.ToInt32(row["MaHDB"]),
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    NgayBan = Convert.ToDateTime(row["NgayBan"]),
                    TienTamTinh = Convert.ToDecimal(row["TienTamTinh"]),
                    ChietKhau = row.Table.Columns.Contains("ChietKhau") ? Convert.ToDecimal(row["ChietKhau"]) : 0,
                    ThueVAT = Convert.ToDecimal(row["ThueVAT"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    TrangThai = row["TrangThai"].ToString()
                });
            }

            return result;
        }



    }
}
