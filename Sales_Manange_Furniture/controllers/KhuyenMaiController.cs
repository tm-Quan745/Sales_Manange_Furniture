using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.controllers;
using Sales_Manange_Furniture.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Sales_Manange_Furniture.controllers
{
    internal class KhuyenMaiController
    {
        private LoginController lgCtrl;
        private string sqlLogin;
        private string sqlPass;
        private DBConnect db;

        public KhuyenMaiController(string userName)
        {
            lgCtrl = new LoginController();
            sqlLogin = lgCtrl.GetSqlLogin(userName);
            sqlPass = lgCtrl.GetSqlPass(userName); // hoặc username tương ứng
            db = new DBConnect("adminLogin", "123456");
        }

        // Load danh sách khuyến mãi
        public List<KhuyenMai> GetAll()
        {
            DataTable dt = db.ExecuteQuery("sp_GetAllKhuyenMai", null, CommandType.StoredProcedure);

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
        public void LoadComboboxes(System.Windows.Forms.ComboBox cbb_ChuongTrinhKM, System.Windows.Forms.ComboBox cbb_SanPham)
        {
            // Load Khuyến mãi
            DataTable dtKM = db.ExecuteQuery("EXEC sp_GetKhuyenMaiForCombo");
            cbb_ChuongTrinhKM.DataSource = dtKM;
            cbb_ChuongTrinhKM.DisplayMember = "TenKM";   // hiển thị tên chương trình
            cbb_ChuongTrinhKM.ValueMember = "MaKM";      // giá trị thật là Mã KM

            // Load Sản phẩm
            DataTable dtSP = db.ExecuteQuery("EXEC sp_GetSanPhamForCombo");
            cbb_SanPham.DataSource = dtSP;
            cbb_SanPham.DisplayMember = "TenSP";     // hiển thị tên sản phẩm
            cbb_SanPham.ValueMember = "MaSP";        // giá trị thật là Mã SP
        }

        // Thêm khuyến mãi
        public int Insert(KhuyenMai km)
        {
            var parameters = new[]
         {
            new SqlParameter("@TenKM", km.TenKM),
            new SqlParameter("@MoTa", km.MoTa),
            new SqlParameter("@LoaiKM", km.LoaiKM),
            new SqlParameter("@GiaTriKM", km.GiaTriKM),
            new SqlParameter("@NgayBatDau", km.NgayBatDau),
            new SqlParameter("@NgayKetThuc", km.NgayKetThuc)
        };

            return db.ExecuteNonQuery("sp_InsertKhuyenMai", parameters, CommandType.StoredProcedure);
        }

        public int Update(KhuyenMai km)
        {
            var parameters = new[]
            {
                new SqlParameter("@MaKM", km.MaKM),
                new SqlParameter("@TenKM", km.TenKM),
                new SqlParameter("@MoTa", km.MoTa),
                new SqlParameter("@LoaiKM", km.LoaiKM),
                new SqlParameter("@GiaTriKM", km.GiaTriKM),
                new SqlParameter("@NgayBatDau", km.NgayBatDau),
                new SqlParameter("@NgayKetThuc", km.NgayKetThuc),
                new SqlParameter("@TrangThai", km.TrangThai)
            };

            return db.ExecuteNonQuery("sp_UpdateKhuyenMai", parameters, CommandType.StoredProcedure);
        }
        public int Delete(int maKM)
        {
            var parameters = new[]
        {
            new SqlParameter("@MaKM", maKM)
        };

            return db.ExecuteNonQuery("sp_DeleteKhuyenMai", parameters, CommandType.StoredProcedure);
        }
        public DataTable Search(string keyword)
        {
            var parameters = new[]
{
            new SqlParameter("@Keyword", keyword)
        };

            return db.ExecuteQuery("sp_SearchKhuyenMai", parameters, CommandType.StoredProcedure);
        }


    }
}
