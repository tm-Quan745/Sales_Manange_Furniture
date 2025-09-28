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

using System.Windows.Input;

namespace Sales_Manage_Furniture.controllers
{
    internal class SanPhamController
    {
            private LoginController lgCtrl;
    private string sqlLogin;
    private string sqlPass;
    private DBConnect db;
        public SanPhamController(string userName)
        {
            lgCtrl = new LoginController();
            sqlLogin = lgCtrl.GetSqlLogin(userName);
            sqlPass = lgCtrl.GetSqlPass(userName); // hoặc username tương ứng
            db = new DBConnect(sqlLogin, sqlPass);
        }

        // Lấy tất cả sản phẩm
        public List<SanPham> GetAll()
        {
            DataTable dt = db.ExecuteQuery(
                                "sp_GetAllSanPham",
                                null,
                                CommandType.StoredProcedure
                            );

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
                        Image resized = ResizeImage(original, 300, 300);
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
            DataTable dt = db.ExecuteQuery(
                         "sp_GetAllSanPham",
                         null,
                         CommandType.StoredProcedure
                     );

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
            SqlParameter[] prms = {
                    new SqlParameter("@keyword", keyword)
            };

            DataTable dt = db.ExecuteQuery(
                "sp_SearchSanPham ",
                prms,
                CommandType.StoredProcedure
            );
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

       
        public SanPham GetById(int maSP)
        {
            SqlParameter[] prms = {
                    new SqlParameter("@MaSP", maSP)
            };

            DataTable dt = db.ExecuteQuery(
                "sp_GetSanPhamByID ",
                prms,
                CommandType.StoredProcedure
            );
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
     

    }
}
