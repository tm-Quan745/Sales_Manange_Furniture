using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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
        // Hàm resize ảnh
        public Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return b;
        }

        // Hàm load danh sách sản phẩm vào DataGridView
        public void LoadSanPhamToGrid(DataGridView dgv, List<SanPham> listSanPham, string imgFolder)
        {
           
            foreach (var sp in listSanPham)
            {
                int rowIndex = dgv.Rows.Add();

                // Đường dẫn ảnh
                string imgPath = Path.Combine(imgFolder, sp.HinhAnh);

                if (File.Exists(imgPath))
                {
                    using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        Image original = Image.FromStream(fs);
                        Image resized = ResizeImage(original, 3000, 3000);
                        dgv.Rows[rowIndex].Cells["HinhAnhCol"].Value = resized;
                    }
                }
                else
                {
                    dgv.Rows[rowIndex].Cells["HinhAnhCol"].Value = null;
                }

                // Load các cột khác
                dgv.Rows[rowIndex].Cells["MaSPCol"].Value = sp.MaSP;
                dgv.Rows[rowIndex].Cells["TenSPCol"].Value = sp.TenSP;
                dgv.Rows[rowIndex].Cells["GiaBanCol"].Value = sp.GiaBan;
                dgv.Rows[rowIndex].Cells["SoLuongCol"].Value = sp.SoLuongTon;
            }
        }

        public List<SanPham> Showdgv()
        {
            string query = "SELECT MaSP, TenSP, MoTa, GiaBan, SoLuongTon, HinhAnh, DonViTinh FROM SanPham";
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
        public SanPham GetById(int maSP)
        {
            string query = "SELECT * FROM SanPham WHERE MaSP=@ma";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ma", maSP)
            };
            DataTable dt = db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new SanPham
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
                };
            }
            return null;
        }
        // Tìm sản phẩm theo tên
        public List<SanPham> search(string tenSP)
        {
            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @TenSP";
            SqlParameter[] parameters =
            {
        new SqlParameter("@TenSP", "%" + tenSP + "%")
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

    }
}
