using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;

namespace Sales_Manage_Furniture.controllers
{
    internal class ChiTietHDBController
    {
        private DBConnect db = new DBConnect();
        private HoaDonController hoaDonCtrl = new HoaDonController();

        // Lấy chi tiết theo mã HDB
        public List<ChiTietHDB> GetByHoaDon(int maHDB)
        {
            string query = "SELECT \r\n    ct.MaSP,\r\n    sp.TenSP,\r\n    ct.SoLuong,\r\n    ct.DonGia,\r\n    km.MaKM,\r\n    km.TenKM,\r\n    ctkm.KieuKM,\r\n    ctkm.GiaTriApDung " +
                "FROM ChiTietHDB ct " +
                "JOIN SanPham sp ON sp.MaSP = ct.MaSP\r\nLEFT JOIN ChiTietKhuyenMai ctkm ON ctkm.MaSP = ct.MaSP\r\nLEFT JOIN KhuyenMai km ON km.MaKM = ctkm.MaKM\r\nWHERE ct.MaHDB = @mahdb;\r\n";
            SqlParameter[] parameters = { new SqlParameter("@mahdb", maHDB) };
            DataTable dt = db.ExecuteQuery(query, parameters);

            List<ChiTietHDB> list = new List<ChiTietHDB>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietHDB
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    MaKM = row["MaKM"] != DBNull.Value ? Convert.ToInt32(row["MaKM"]) : (int?)null,
                    GiaTriKM = row["GiaTriApDung"] != DBNull.Value ? Convert.ToDecimal(row["GiaTriApDung"]) : 0,
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    
                });
            }
            return list;
        }

        // Thêm chi tiết hóa đơn
        public bool Insert(ChiTietHDB ct)
        {
            string query = @"INSERT INTO ChiTietHDB(MaHDB, MaSP, SoLuong, DonGia, MaKM) 
                             VALUES (@mahdb, @masp, @soluong, @dongia, @makm)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", ct.MaHDB),
                new SqlParameter("@masp", ct.MaSP),
                new SqlParameter("@soluong", ct.SoLuong),
                new SqlParameter("@dongia", ct.DonGia),
                new SqlParameter("@makm", ct.MaKM.HasValue ? (object)ct.MaKM.Value : DBNull.Value)
            };

            bool success = db.ExecuteNonQuery(query, parameters) > 0;

            return success;
        }

        // Cập nhật chi tiết hóa đơn
        public bool Update(ChiTietHDB ct, decimal vatRate = 0.1m, decimal khuyenMai = 0)
        {
            string query = @"UPDATE ChiTietHDB 
                             SET SoLuong=@soluong, DonGia=@dongia 
                             WHERE MaHDB=@mahdb AND MaSP=@masp";
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", ct.MaHDB),
                new SqlParameter("@masp", ct.MaSP),
                new SqlParameter("@soluong", ct.SoLuong),
                new SqlParameter("@dongia", ct.DonGia)
            };

            bool success = db.ExecuteNonQuery(query, parameters) > 0;

           

            return success;
        }

        // Xóa chi tiết hóa đơn
        public bool Delete(int maHDB, int maSP, decimal vatRate = 0.1m, decimal khuyenMai = 0)
        {
            string query = "DELETE FROM ChiTietHDB WHERE MaHDB=@mahdb AND MaSP=@masp";
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", maHDB),
                new SqlParameter("@masp", maSP)
            };

            bool success = db.ExecuteNonQuery(query, parameters) > 0;

            
            return success;
        }
    }
}
