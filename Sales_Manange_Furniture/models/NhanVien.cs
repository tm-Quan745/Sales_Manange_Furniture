using System;

namespace Sales_Manage_Furniture.Models
{
    public class NhanVien
    {
        private int maNV;
        private string hoTen;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
        private string soDienThoai;
        private string email;
        private string chucVu;

        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
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

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        // Constructor mặc định
        public NhanVien() { }

        // Constructor có tham số
        public NhanVien(int maNV, string hoTen, string gioiTinh, DateTime ngaySinh,
                        string diaChi, string soDienThoai, string email, string chucVu)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.chucVu = chucVu;
        }

        public override string ToString()
        {
            return $"{HoTen} - {ChucVu}";
        }
    }
}
