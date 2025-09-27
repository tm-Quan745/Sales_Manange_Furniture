using Sales_Manage_Furniture.config;
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
        public void LoadComboboxes(System.Windows.Forms.ComboBox cbb_ChuongTrinhKM, System.Windows.Forms.ComboBox cbb_SanPham)
        {
            // Load Khuyến mãi
            string sqlKM = "SELECT MaKM, TenKM FROM KhuyenMai";
            DataTable dtKM = db.ExecuteQuery(sqlKM);
            cbb_ChuongTrinhKM.DataSource = dtKM;
            cbb_ChuongTrinhKM.DisplayMember = "TenKM";   // hiển thị tên chương trình
            cbb_ChuongTrinhKM.ValueMember = "MaKM";      // giá trị thật là Mã KM

            // Load Sản phẩm
            string sqlSP = "SELECT MaSP, TenSP FROM SanPham";
            DataTable dtSP = db.ExecuteQuery(sqlSP);
            cbb_SanPham.DataSource = dtSP;
            cbb_SanPham.DisplayMember = "TenSP";     // hiển thị tên sản phẩm
            cbb_SanPham.ValueMember = "MaSP";        // giá trị thật là Mã SP
        }

        // Thêm khuyến mãi
        public int Insert(KhuyenMai km)
        {
            string query = @"INSERT INTO KhuyenMai (TenKM, MoTa, LoaiKM, GiaTriKM, NgayBatDau, NgayKetThuc)
                     VALUES (@TenKM, @MoTa, @LoaiKM, @GiaTriKM, @NgayBatDau, @NgayKetThuc)";

            var parameters = new[]
            {
                new SqlParameter("@TenKM", km.TenKM),
                new SqlParameter("@MoTa", km.MoTa),
                new SqlParameter("@LoaiKM", km.LoaiKM),
                new SqlParameter("@GiaTriKM", km.GiaTriKM),
                new SqlParameter("@NgayBatDau", km.NgayBatDau),
                new SqlParameter("@NgayKetThuc", km.NgayKetThuc)
            };

            return db.ExecuteNonQuery(query, parameters);
        }
        public int Update(KhuyenMai km)
        {
            string query = @"UPDATE KhuyenMai
                     SET TenKM = @TenKM,
                         MoTa = @MoTa,
                         LoaiKM = @LoaiKM,
                         GiaTriKM = @GiaTriKM,
                         NgayBatDau = @NgayBatDau,
                         NgayKetThuc = @NgayKetThuc,
                         TrangThai = @TrangThai
                     WHERE MaKM = @MaKM";

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

            return db.ExecuteNonQuery(query, parameters);
        }
        public int Delete(int maKM)
        {
            string query = "DELETE FROM KhuyenMai WHERE MaKM = @MaKM";

            var parameters = new[]
            {
                new SqlParameter("@MaKM", maKM)
            };

            return db.ExecuteNonQuery(query, parameters);
        }
        public DataTable Search(string keyword)
        {
            string query = @"SELECT * FROM KhuyenMai
                     WHERE TenKM LIKE @Keyword";

            var parameters = new[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            return db.ExecuteQuery(query, parameters);
        }


    }
}
