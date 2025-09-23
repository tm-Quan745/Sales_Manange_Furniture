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
            string query = @"INSERT INTO HoaDonBan(MaKH, MaNV, NgayBan, TienTamTinh, VAT, MaKM, TongTien, TrangThai) 
                             VALUES (@makh, @manv, @ngayban, @TienTamTinh, @vat, @MaKM, @tongtien, @trangthai)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@makh", hd.MaKH),
                new SqlParameter("@manv", hd.MaNV),
                new SqlParameter("@ngayban", hd.NgayBan),
                new SqlParameter("@TienTamTinh", hd.TienTamTinh),
                new SqlParameter("@vat", hd.ThueVAT),
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


        // Tính tiền hóa đơn dựa trên chi tiết
        public HoaDon TinhTien(int maHDB, decimal vatRate = 0.1m, decimal MaKM = 0)
        {
            string query = "SELECT SoLuong, DonGia FROM ChiTietHDB WHERE MaHDB=@mahdb";
            SqlParameter[] parameters = { new SqlParameter("@mahdb", maHDB) };
            DataTable dt = db.ExecuteQuery(query, parameters);

            decimal TienTamTinh = 0;
            foreach (DataRow row in dt.Rows)
            {
                TienTamTinh += Convert.ToInt32(row["SoLuong"]) * Convert.ToDecimal(row["DonGia"]);
            }

            decimal vat = TienTamTinh * vatRate;
            decimal tongTien = TienTamTinh + vat - MaKM;

            // cập nhật vào DB
            string updateQuery = @"UPDATE HoaDonBan 
                                   SET TienTamTinh=@TienTamTinh, VAT=@vat, MaKM=@MaKM, TongTien=@tongtien
                                   WHERE MaHDB=@mahdb";
            SqlParameter[] updateParams =
            {
                new SqlParameter("@TienTamTinh", TienTamTinh),
                new SqlParameter("@vat", vat),
                new SqlParameter("@MaKM", MaKM),
                new SqlParameter("@tongtien", tongTien),
                new SqlParameter("@mahdb", maHDB)
            };
            db.ExecuteNonQuery(updateQuery, updateParams);

            return GetById(maHDB);
        }
    }
}
