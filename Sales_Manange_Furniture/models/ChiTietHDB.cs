using System;

namespace Sales_Manage_Furniture.Models
{
    public class ChiTietHDB
    {
        private int maHDB;
        private int maSP;
        private int soLuong;
        private decimal donGia;
        private decimal thanhTien;

        public int MaHDB
        {
            get { return maHDB; }
            set { maHDB = value; }
        }

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public decimal DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public decimal ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        // Constructor mặc định
        public ChiTietHDB() { }

        // Constructor có tham số
        public ChiTietHDB(int maHDB, int maSP, int soLuong, decimal donGia)
        {
            this.maHDB = maHDB;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thanhTien = soLuong * donGia; // tự động tính
        }

        public override string ToString()
        {
            return $"SP#{MaSP} - SL: {SoLuong} - Giá: {DonGia:C} - Thành tiền: {ThanhTien:C}";
        }
    }
}
