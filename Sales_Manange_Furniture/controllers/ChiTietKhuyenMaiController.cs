using Sales_Manage_Furniture.config;
using Sales_Manange_Furniture.models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Manange_Furniture.controllers
{
    internal class ChiTietKhuyenMaiController
    {
        private DBConnect db = new DBConnect();

        // Load chi tiết KM theo chương trình
        public List<ChiTietKhuyenMai> GetByKhuyenMai(int maKM)
        {
            string query = "SELECT * FROM ChiTietKhuyenMai WHERE MaKM = @MaKM";
            var parameters = new[] { new System.Data.SqlClient.SqlParameter("@MaKM", maKM) };

            DataTable dt = db.ExecuteQuery(query, parameters);

            List<ChiTietKhuyenMai> list = new List<ChiTietKhuyenMai>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietKhuyenMai
                {
                    MaCTKM = Convert.ToInt32(row["MaCTKM"]),
                    MaKM = Convert.ToInt32(row["MaKM"]),
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    GiaTriApDung = Convert.ToDecimal(row["GiaTriApDung"]),
                    KieuKM = row["KieuKM"].ToString()
                });
            }
            return list;
        }

        public List<ChiTietKhuyenMai> GetAll()
        {
            string query = @"
                SELECT ctkm.MaCTKM, 
                       ctkm.MaKM, km.TenKM, 
                       ctkm.MaSP, sp.TenSP,ctkm.KieuKM, 
                       ctkm.GiaTriApDung
                FROM ChiTietKhuyenMai ctkm
                INNER JOIN KhuyenMai km ON ctkm.MaKM = km.MaKM
                INNER JOIN SanPham sp ON ctkm.MaSP = sp.MaSP";

            DataTable dt = db.ExecuteQuery(query);
            List<ChiTietKhuyenMai> list = new List<ChiTietKhuyenMai>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietKhuyenMai
                {
                    MaCTKM = Convert.ToInt32(row["MaCTKM"]),
                    MaKM = Convert.ToInt32(row["MaKM"]),
                    TenKM = row["TenKM"].ToString(),
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    KieuKM = row["KieuKM"].ToString(),
                    GiaTriApDung = Convert.ToDecimal(row["GiaTriApDung"]),

                    // Thêm thuộc tính hiển thị
                    
                 
                });
            }

            return list;
        }

        // Thêm chi tiết KM
        public int Insert(ChiTietKhuyenMai ctkm)
        {
            string query = @"INSERT INTO ChiTietKhuyenMai (MaKM, MaSP, GiaTriApDung)
                             VALUES (@MaKM, @MaSP, @GiaTriApDung)";

            var parameters = new[]
            {
                new System.Data.SqlClient.SqlParameter("@MaKM", ctkm.MaKM),
                new System.Data.SqlClient.SqlParameter("@MaSP", ctkm.MaSP),
                new System.Data.SqlClient.SqlParameter("@GiaTriApDung", ctkm.GiaTriApDung)
            };

            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
