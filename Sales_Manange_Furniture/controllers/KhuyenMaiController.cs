using Sales_Manage_Furniture.config;
using Sales_Manange_Furniture.models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Manange_Furniture.controllers
{
    internal class KhuyenMaiController
    {
        private DBConnect db = new DBConnect();

        // Load danh sách khuyến mãi
        public List<KhuyenMai> GetAll()
        {
            string query = "SELECT * FROM KhuyenMai";
            DataTable dt = db.ExecuteQuery(query);

            List<KhuyenMai> list = new List<KhuyenMai>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhuyenMai
                {
                    MaKM = Convert.ToInt32(row["MaKM"]),
                    TenKM = row["TenKM"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    LoaiKM = row["LoaiKM"].ToString(),
                    GiaTriKM = Convert.ToDecimal(row["GiaTriKM"]),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])

                });
            }
            return list;
        }

        // Thêm khuyến mãi
        public int Insert(KhuyenMai km)
        {
            string query = @"INSERT INTO KhuyenMai (TenKM, MoTa, NgayBatDau, NgayKetThuc, PhanTramGiam)
                             VALUES (@TenKM, @MoTa, @NgayBatDau, @NgayKetThuc, @PhanTramGiam)";

            var parameters = new[]
            {
                new System.Data.SqlClient.SqlParameter("@TenKM", km.TenKM),
                new System.Data.SqlClient.SqlParameter("@MoTa", km.MoTa),
                new System.Data.SqlClient.SqlParameter("@LoaiKM", km.LoaiKM),
                new System.Data.SqlClient.SqlParameter("@GiaTriKhuyenMai", km.GiaTriKM),
                new System.Data.SqlClient.SqlParameter("@NgayBatDau", km.NgayBatDau),
                new System.Data.SqlClient.SqlParameter("@NgayKetThuc", km.NgayKetThuc),
                
            };

            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
