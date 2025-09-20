using System;

namespace Sales_Manage_Furniture.models
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhau;
        private int maNV;
        private string quyenHan;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string Quyen
        {
            get { return quyenHan; }
            set { quyenHan = value; }
        }

        // Constructor mặc định
        public TaiKhoan() { }

        // Constructor có tham số
        public TaiKhoan(string tenDangNhap, string matKhau, int maNV, string quyenHan)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.maNV = maNV;
            this.quyenHan = quyenHan;
        }

        public override string ToString()
        {
            return $"{TenDangNhap} - {Quyen}";
        }
    }
}
