using System;

namespace Sales_Manage_Furniture.models
{
    public class KhachHang
    {
        private int maKH;
        private string hoTen;
        private string diaChi;
        private string soDienThoai;
        private string email;

        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Constructor mặc định
        public KhachHang() { }

        // Constructor có tham số
        public KhachHang(int maKH, string hoTen, string diaChi, string soDienThoai, string email)
        {
            this.maKH = maKH;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.email = email;
        }

        public override string ToString()
        {
            return $"{HoTen} - {SoDienThoai}";
        }
    }
}
