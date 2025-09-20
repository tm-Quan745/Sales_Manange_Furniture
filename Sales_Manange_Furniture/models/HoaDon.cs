using System;

namespace Sales_Manage_Furniture.models
{
    public class HoaDon
    {
        private int maHDB;
        private int maKH;
        private int maNV;
        private DateTime ngayBan;
        private decimal tongTien;
        private string trangThai;

        public int MaHDB
        {
            get { return maHDB; }
            set { maHDB = value; }
        }

        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        // Constructor mặc định
        public HoaDon() { }

        // Constructor có tham số
        public HoaDon(int maHDB, int maKH, int maNV, DateTime ngayBan, decimal tongTien, string trangThai)
        {
            this.maHDB = maHDB;
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayBan = ngayBan;
            this.tongTien = tongTien;
            this.trangThai = trangThai;
        }

        public override string ToString()
        {
            return $"HĐ#{MaHDB} - Ngày: {NgayBan.ToShortDateString()} - Tổng: {TongTien:C}";
        }
    }
}
