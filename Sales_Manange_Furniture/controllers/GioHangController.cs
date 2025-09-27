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

        // 🛒 Cập nhật lại textbox tính toán mỗi khi giỏ hàng thay đổi
        public void CapNhatThanhTien()
        {
            decimal tamTinh = this.TinhTamTinh(dgv);
            decimal ck = this.TinhChietKhau(dgv);
            decimal vat = this.TinhVAT(dgv);
            decimal tongTien = this.TinhTongTien(dgv);

            txtTamTinh.Text = tamTinh.ToString("N0");
            txtChietKhau.Text = ck.ToString("N0");
            txtVAT.Text = vat.ToString("N0");
            txtTongTien.Text = tongTien.ToString("N0");
        }

        // 🛒 Hàm tính tạm tiền một dòng (chỉ đơn giá * SL, không KM, không VAT)
        public decimal TinhTienDong(decimal donGia, int soLuong)
        {
            return donGia * soLuong;
        }
        public List<GioHang> GetGioHang()
        {
            return gioHang;
        }

        // Lấy thông tin sản phẩm từ DB
        public GioHang GetSanPhamFromDB(int maSP, int soLuong)
        {
            string query = @"
            SELECT sp.MaSP, sp.TenSP, sp.GiaBan, sp.ThueVAT,
            km.MaKM, km.GiaTriApDung, km.KieuKM
            FROM SanPham sp
            LEFT JOIN ChiTietKhuyenMai km ON sp.MaSP = km.MaSP
            WHERE sp.MaSP = @MaSP";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaSP", maSP)
    };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int maKM = row["MaKM"] != DBNull.Value ? Convert.ToInt32(row["MaKM"]) : 0;
                decimal giaTriApDung = row["GiaTriApDung"] != DBNull.Value ? Convert.ToDecimal(row["GiaTriApDung"]) : 0;
                string kieuKM = row["KieuKM"] != DBNull.Value ? row["KieuKM"].ToString() : "";
                decimal donGia = Convert.ToDecimal(row["GiaBan"]);
                decimal thueVAT = row["ThueVAT"] != DBNull.Value ? Convert.ToDecimal(row["ThueVAT"]) : 0;

                return new GioHang
                {
                    MaSP = Convert.ToInt32(row["MaSP"]), 
                    TenSP = row["TenSP"].ToString(),
                    MaKM = maKM,
                    GiaTriApDung = giaTriApDung,
                    KieuKM = kieuKM,
                    DonGia = donGia,
                    SoLuong = soLuong,
                    TongTien = donGia * soLuong, // dgv hiển thị raw total
                    ThueVAT = thueVAT
                };
            }

            return null;
        }


        // Thêm sản phẩm vào giỏ
        public void AddToCart(int maSP, int soLuong)
        {
            GioHang existing = gioHang.Find(x => x.MaSP == maSP);
            if (existing != null)
            {
                existing.SoLuong += soLuong;
                decimal donGia = existing.TongTien / (existing.SoLuong - soLuong);
                existing.TongTien = donGia * existing.SoLuong;
            }
            else
            {
                GioHang sp = GetSanPhamFromDB(maSP, soLuong);
                if (sp != null)
                {
                    gioHang.Add(sp);
                }
            }
        }

        public void RemoveFromCart(int maSP)
        {
            gioHang.RemoveAll(x => x.MaSP == maSP);
        }

        public void UpdateSoLuong(int maSP, int soLuong)
        {
            GioHang item = gioHang.Find(x => x.MaSP == maSP);
            if (item != null)
            {
                decimal donGia = item.TongTien / (item.SoLuong == 0 ? 1 : item.SoLuong);
                item.SoLuong = soLuong;
                item.TongTien = donGia * soLuong;
            }
        }

        // =========================
        // 📌 CÁC HÀM TÍNH TOÁN
        // =========================

        public decimal TinhTamTinh(DataGridView dgv)
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue; // bỏ dòng trống cuối dgv

                decimal donGia = Convert.ToDecimal(row.Cells["col_DonGia"].Value);
                int soLuong = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);

                tong += donGia * soLuong;
            }
            return tong;
        }

        public decimal TinhChietKhau(DataGridView dgv)
        {
            decimal ck = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                decimal donGia = Convert.ToDecimal(row.Cells["col_DonGia"].Value);
                int soLuong = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);

                string kmStr = row.Cells["col_KM"].Value?.ToString();

                if (string.IsNullOrEmpty(kmStr)) continue;

                if (kmStr.Contains("%"))
                {
                    // Trường hợp giảm theo %
                    decimal percent = Convert.ToDecimal(kmStr.Replace("%", "").Trim());
                    ck += (donGia * soLuong) * (percent / 100);
                }
                else
                {
                    // Trường hợp giảm trực tiếp theo số tiền
                    decimal amount = Convert.ToDecimal(kmStr);
                    ck += amount * soLuong;
                }
            }

            return ck;
        }


        public decimal TinhVAT(DataGridView dgv)
        {
            decimal vat = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                decimal donGia = Convert.ToDecimal(row.Cells["col_DonGia"].Value);
                int soLuong = Convert.ToInt32(row.Cells["col_SoLuongb"].Value);
                string kmStr = row.Cells["col_KM"].Value?.ToString();
                decimal Vat = Convert.ToDecimal(row.Cells["col_VAT"].Value);

                // Giá gốc
                decimal giaSauKM = donGia * soLuong;

                // Áp dụng chiết khấu
                if (!string.IsNullOrEmpty(kmStr))
                {
                    if (kmStr.Contains("%"))
                    {
                        decimal percent = Convert.ToDecimal(kmStr.Replace("%", "").Trim());
                        giaSauKM -= giaSauKM * (percent / 100);
                    }
                    else
                    {
                        decimal amount = Convert.ToDecimal(kmStr);
                        giaSauKM -= amount * soLuong;
                    }
                }

                if (giaSauKM < 0) giaSauKM = 0;

                // Tính VAT cho sản phẩm này
                vat += giaSauKM * Vat / 100;
            }

            return vat;
        }

        public decimal TinhTongTien(DataGridView dgv)
        {
            return TinhTamTinh(dgv) - TinhChietKhau(dgv) + TinhVAT(dgv);
        }

    }
}
    
