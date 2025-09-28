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
        private DBConnect db;
        private LoginController lgCtrl;
        public HoaDonController(string username)
        {
            lgCtrl = new LoginController();
            string sqlLogin = lgCtrl.GetSqlLogin(username);
            string sqlPass = lgCtrl.GetSqlPass(username);
            db = new DBConnect(sqlLogin, sqlPass);
        }

        // Lấy tất cả hóa đơn
        public List<HoaDon> GetAll()
        {
            DataTable dt = db.ExecuteQuery("sp_GetAllHoaDon");
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

        public int ThemHoaDonFull(HoaDon hd, DataTable chiTiet)
        {
            SqlParameter[] parameters =
            {
            new SqlParameter("@MaKH", hd.MaKH),
            new SqlParameter("@MaNV", hd.MaNV),
            new SqlParameter("@NgayBan", hd.NgayBan),
            new SqlParameter("@TienTamTinh", hd.TienTamTinh),
            new SqlParameter("@ThueVAT", hd.ThueVAT),
            new SqlParameter("@ChietKhau", hd.ChietKhau),
            new SqlParameter("@TongTien", hd.TongTien),
            new SqlParameter("@TrangThai", hd.TrangThai),
            new SqlParameter("@ChiTietHoaDon", SqlDbType.Structured)
            {
                TypeName = "dbo.CTHoaDonType",
                Value = chiTiet
            }
        };

            object result = db.ExecuteScalar("sp_InsertHoaDonFull", parameters, CommandType.StoredProcedure);
            return Convert.ToInt32(result);
        }


        // Thêm hóa đơn mới
        public int InsertAndReturnId(HoaDon hd)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaKH", hd.MaKH),
                new SqlParameter("@MaNV", hd.MaNV),
                new SqlParameter("@NgayBan", hd.NgayBan),
                new SqlParameter("@TienTamTinh", hd.TienTamTinh),
                new SqlParameter("@ThueVAT", hd.ThueVAT),
                new SqlParameter("@ChietKhau", hd.ChietKhau),
                new SqlParameter("@TongTien", hd.TongTien),
                new SqlParameter("@TrangThai", hd.TrangThai),
                new SqlParameter("@NewMaHDB", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            db.ExecuteNonQuery("sp_InsertHoaDon", parameters, CommandType.StoredProcedure);

            return (int)parameters[8].Value; // vị trí 8 là @NewMaHDB
        }


        // Cập nhật trạng thái hóa đơn
        public bool UpdateTrangThaiHD(int maHDB, string trangThai)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaHDB", maHDB),
                new SqlParameter("@TrangThai", trangThai)
            };
            int rowsAffected = db.ExecuteNonQuery("sp_UpdateTrangThaiHoaDon", parameters, CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

        // Lấy hóa đơn theo ID
        public HoaDon GetById(int maHDB)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@mahdb", maHDB)
            };
            DataTable dt = db.ExecuteQuery("sp_GetHoaDonByID", parameters, CommandType.StoredProcedure);
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
            SqlParameter[] parameters =
            {
        new SqlParameter("@mahdb", maHDB)
    };

            DataTable dt = db.ExecuteQuery("sp_SearchHoaDon", parameters, CommandType.StoredProcedure);

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
            SqlParameter[] parameters =
            {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };

            DataTable dt = db.ExecuteQuery("sp_SearchHoaDon", parameters, CommandType.StoredProcedure);

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
