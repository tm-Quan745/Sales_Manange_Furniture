using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.config;
using System.Windows.Forms;

namespace Sales_Manage_Furniture.controllers
{
    public class GioHangController
    {
        private List<GioHang> gioHang = new List<GioHang>();
        private DBConnect db = new DBConnect();
        private DataGridView dgv;
        private TextBox txtTamTinh;
        private TextBox txtChietKhau;
        private TextBox txtVAT;
        private TextBox txtTongTien;

        public GioHangController(DataGridView dgv, TextBox txtTamTinh, TextBox txtChietKhau, TextBox txtVAT, TextBox txtTongTien)
        {
            this.dgv = dgv;
            this.txtTamTinh = txtTamTinh;
            this.txtChietKhau = txtChietKhau;
            this.txtVAT = txtVAT;
            this.txtTongTien = txtTongTien;
        }

        public DataTable GetGioHang(string sessionID)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@SessionID", sessionID),
            new SqlParameter("NgayApDung", DateTime.Now)
        };

            return db.ExecuteQuery("sp_GetGioHang_WithDiscounts", parameters, CommandType.StoredProcedure);
        }

        public void CapNhatThanhTien(string sessionID,
                                     TextBox txtTamTinh,
                                     TextBox txtChietKhau,
                                     TextBox txtVAT,
                                     TextBox txtTongTien)
        {
            string query = "SELECT * FROM dbo.fn_TinhTongTien(@SessionID,@NgayApDung)";
            SqlParameter[] parameters = { new SqlParameter("@SessionID", sessionID),
                                          new SqlParameter("@NgayApDung", DateTime.Now)};
            DataTable dt = db.ExecuteQuery(query, parameters, CommandType.Text);

            if (dt.Rows.Count > 0)
            {
                txtTamTinh.Text = dt.Rows[0]["TamTinh"] != DBNull.Value
                 ? Convert.ToDecimal(dt.Rows[0]["TamTinh"]).ToString("N0") : "0";

                txtChietKhau.Text = dt.Rows[0]["ChietKhau"] != DBNull.Value
                    ? Convert.ToDecimal(dt.Rows[0]["ChietKhau"]).ToString("N0")
                    : "0";

                txtVAT.Text = dt.Rows[0]["VAT"] != DBNull.Value
                    ? Convert.ToDecimal(dt.Rows[0]["VAT"]).ToString("N0")
                    : "0";

                txtTongTien.Text = dt.Rows[0]["TongTien"] != DBNull.Value
                    ? Convert.ToDecimal(dt.Rows[0]["TongTien"]).ToString("N0")
                    : "0";

            }
        }


        public List<GioHang> GetGioHang()
        {
            return gioHang;
        }

        // Thêm sản phẩm vào giỏ
        public void ThemVaoGio(string sessionID, int maSP, int soLuong, string danhsachKM)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@SessionID", sessionID),
                new SqlParameter("@MaSP", maSP),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@DanhSachKM", danhsachKM) 
            };
            db.ExecuteNonQuery("sp_ThemVaoGio", parameters, CommandType.StoredProcedure);
        }


        public void XoaKhoiGio(string sessionID, int maSP)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@SessionID", sessionID),
                new SqlParameter("@MaSP", maSP)
            };
            db.ExecuteNonQuery("sp_XoaKhoiGio", parameters, CommandType.StoredProcedure);
        }

        public void HuyGioHang(string sessionID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@SessionID", sessionID)
            };
            db.ExecuteNonQuery("sp_HuyGioHang", parameters, CommandType.StoredProcedure);
        }


    }
}
    
