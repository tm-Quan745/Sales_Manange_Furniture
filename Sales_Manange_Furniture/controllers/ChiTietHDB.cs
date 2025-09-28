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
        
        DBConnect db ;
        LoginController lgCtrl = new LoginController();
        HoaDonController hoaDonCtrl;

        public ChiTietHDBController(string username)
        {
            string sqllogin = lgCtrl.GetSqlLogin(username);
            string sqlpass = lgCtrl.GetSqlPass(username);
            db = new DBConnect(sqllogin, sqlpass);
            hoaDonCtrl = new HoaDonController(username);
        }
        // Lấy chi tiết theo mã HDB
        public List<ChiTietHDB> GetByHoaDon(int maHDB)
        { 
            SqlParameter[] parameters = { new SqlParameter("@mahdb", maHDB) };
            DataTable dt = db.ExecuteQuery("sp_GetChiTietHDBByHoaDon", parameters, CommandType.StoredProcedure);

            List<ChiTietHDB> list = new List<ChiTietHDB>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietHDB
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    DanhSachKM = row["DanhSachKM"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    
                });
            }
            return list;
        }

        // Thêm chi tiết hóa đơn
        public bool Insert(ChiTietHDB ct)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", ct.MaHDB),
                new SqlParameter("@masp", ct.MaSP),
                new SqlParameter("@soluong", ct.SoLuong),
                new SqlParameter("@dongia", ct.DonGia),
                new SqlParameter("@danhsachkm", ct.DanhSachKM)
            };

            bool success = db.ExecuteNonQuery("sp_InsertChiTietHDB", parameters, CommandType.StoredProcedure) > 0;

            return success;
        }
    }
}
