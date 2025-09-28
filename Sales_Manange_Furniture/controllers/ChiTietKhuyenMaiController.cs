using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.controllers;
using Sales_Manange_Furniture.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sales_Manange_Furniture.controllers
{
    internal class ChiTietKhuyenMaiController
    {

        DBConnect db;
        LoginController lgCtrl = new LoginController();

        public ChiTietKhuyenMaiController(string username)
        {
            string sqllogin = lgCtrl.GetSqlLogin(username);
            string sqlpass = lgCtrl.GetSqlPass(username);
            db = new DBConnect(sqllogin, sqlpass);
        }

        // Load chi tiết KM theo chương trình
        public List<ChiTietKhuyenMai> GetByKhuyenMai(int maKM)
        {
            string query = "sp_GetChiTietKhuyenMaiByMaKM @MaKM";
            var parameters = new[] { new SqlParameter("@MaKM", maKM) };

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
            string query = "sp_GetAllChiTietKhuyenMai";
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
           
            var parameters = new[]
            {
                new SqlParameter("@MaKM", ctkm.MaKM),
                new SqlParameter("@MaSP", ctkm.MaSP),
                new SqlParameter("@KieuKM", ctkm.KieuKM ?? (object)DBNull.Value),
                new SqlParameter("@GiaTriApDung", ctkm.GiaTriApDung)
            };

            return db.ExecuteNonQuery("sp_InsertChiTietKhuyenMai", parameters, CommandType.StoredProcedure);
        }

        public int Update(ChiTietKhuyenMai ctkm)
        {
            var parameters = new[]
            {
                new SqlParameter("@KieuKM", ctkm.KieuKM),
                new SqlParameter("@GiaTriApDung", ctkm.GiaTriApDung),
                new SqlParameter("@MaKM", ctkm.MaKM),
                new SqlParameter("@MaSP", ctkm.MaSP)
            };

            return db.ExecuteNonQuery("sp_UpdateChiTietKhuyenMai", parameters, CommandType.StoredProcedure);
        }

        public int Delete(int maKM, int maSP)
        {
            var parameters = new[]
            {
                new SqlParameter("@MaKM", maKM),
                new SqlParameter("@MaSP", maSP)
            };

            return db.ExecuteNonQuery("sp_DeleteChiTietKhuyenMai", parameters, CommandType.StoredProcedure);
        }

        public DataTable Search(string keyword)
        {
            var parameters = new[]  
            {
                new SqlParameter("@Keyword", "%" + keyword + "%") 
            };

            return db.ExecuteQuery("sp_SearchChiTietKhuyenMai", parameters, CommandType.StoredProcedure);
        }

        public decimal GetDiscountForProduct(int maSP, DateTime ngayApDung)
        {
            string query = "SELECT dbo.fn_GetDiscountForProduct(@MaSP, @NgayApDung)";
            var parameters = new[]
            {
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@NgayApDung", ngayApDung)
            };

            object result = db.ExecuteScalar(query, parameters);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

    }
}
 