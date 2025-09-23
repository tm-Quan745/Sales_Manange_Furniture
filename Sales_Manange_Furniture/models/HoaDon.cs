using System;

namespace Sales_Manage_Furniture.models
{
    public class HoaDon
    {
        public int MaHDB { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayBan { get; set; }

        public decimal TienTamTinh { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal ThueVAT { get; set; }
        public decimal TongTien { get; set; }

        public string TrangThai { get; set; }

        public HoaDon() { }

        public HoaDon(int maHDB, int maKH, int maNV, DateTime ngayBan,
                      decimal tienTamTinh, decimal vat, decimal tongTien,
                      string trangThai, int? maKM = null, string tenKM = null)
        {
            MaHDB = maHDB;
            MaKH = maKH;
            MaNV = maNV;
            NgayBan = ngayBan;
            TienTamTinh = tienTamTinh;
            ThueVAT = vat;
            TongTien = tongTien;
            TrangThai = trangThai;
            
        }
    }

}
