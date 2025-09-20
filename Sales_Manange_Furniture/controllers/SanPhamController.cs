using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.config;
using Sales_Manage_Furniture.models;

namespace Sales_Manage_Furniture.controllers
{
    internal class SanPhamController
    {
        private DBConnect db = new DBConnect();

        // Lấy tất cả sản phẩm
        public List<SanPham> GetAll()
        {
            string query = "SELECT * FROM SanPham";
            DataTable dt = db.ExecuteQuery(query);
            List<SanPham> list = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SanPham
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    GiaBan = Convert.ToDecimal(row["GiaBan"]),
                    SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                    MaLoaiSP = Convert.ToInt32(row["MaLoaiSP"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    HinhAnh = row["HinhAnh"].ToString(),
                    DonViTinh = row["DonViTinh"].ToString()
                });
            }
            return list;
        }

        // Tìm sản phẩm theo tên hoặc loại
        public List<SanPham> Search(string keyword)
        {
            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @kw";
            SqlParameter[] parameters =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            List<SanPham> list = new List<SanPham>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SanPham
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = row["TenSP"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    GiaBan = Convert.ToDecimal(row["GiaBan"]),
                    SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                    MaLoaiSP = Convert.ToInt32(row["MaLoaiSP"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    HinhAnh = row["HinhAnh"].ToString(),
                    DonViTinh = row["DonViTinh"].ToString()
                });
            }
            return list;
        }

        // Thêm sản phẩm
        public bool Insert(SanPham sp)
        {
            string query = @"INSERT INTO SanPham 
                            (TenSP, MoTa, GiaBan, SoLuongTon, MaLoaiSP, MaNCC, HinhAnh, DonViTinh) 
                            VALUES (@ten, @mota, @gia, @soluong, @maloai, @mancc, @hinhanh, @donvi)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ten", sp.TenSP),
                new SqlParameter("@mota", sp.MoTa),
                new SqlParameter("@gia", sp.GiaBan),
                new SqlParameter("@soluong", sp.SoLuongTon),
                new SqlParameter("@maloai", sp.MaLoaiSP),
                new SqlParameter("@mancc", sp.MaNCC),
                new SqlParameter("@hinhanh", sp.HinhAnh),
                new SqlParameter("@donvi", sp.DonViTinh)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật sản phẩm
        public bool Update(SanPham sp)
        {
            string query = @"UPDATE SanPham 
                            SET TenSP=@ten, MoTa=@mota, GiaBan=@gia, SoLuongTon=@soluong, 
                                MaLoaiSP=@maloai, MaNCC=@mancc, HinhAnh=@hinhanh, DonViTinh=@donvi
                            WHERE MaSP=@ma";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ten", sp.TenSP),
                new SqlParameter("@mota", sp.MoTa),
                new SqlParameter("@gia", sp.GiaBan),
                new SqlParameter("@soluong", sp.SoLuongTon),
                new SqlParameter("@maloai", sp.MaLoaiSP),
                new SqlParameter("@mancc", sp.MaNCC),
                new SqlParameter("@hinhanh", sp.HinhAnh),
                new SqlParameter("@donvi", sp.DonViTinh),
                new SqlParameter("@ma", sp.MaSP)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa sản phẩm
        public bool Delete(int maSP)
        {
            string query = "DELETE FROM SanPham WHERE MaSP=@ma";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ma", maSP)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
