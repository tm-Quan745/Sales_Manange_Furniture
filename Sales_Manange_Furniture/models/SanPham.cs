using System;

namespace Sales_Manage_Furniture.Models
{
    public class SanPham
    {
        private int maSP;
        private string tenSP;
        private string moTa;
        private decimal giaBan;
        private int soLuongTon;
        private int maLoaiSP;
        private int maNCC;
        private string hinhAnh;
        private string donViTinh;

        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        public decimal GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        public int SoLuongTon
        {
            get { return soLuongTon; }
            set { soLuongTon = value; }
        }

        public int MaLoaiSP
        {
            get { return maLoaiSP; }
            set { maLoaiSP = value; }
        }

        public int MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        public string HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }

        public string DonViTinh
        {
            get { return donViTinh; }
            set { donViTinh = value; }
        }

        // Constructor mặc định
        public SanPham() { }

        // Constructor có tham số
        public SanPham(int maSP, string tenSP, string moTa, decimal giaBan, int soLuongTon,
                       int maLoaiSP, int maNCC, string hinhAnh, string donViTinh)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.moTa = moTa;
            this.giaBan = giaBan;
            this.soLuongTon = soLuongTon;
            this.maLoaiSP = maLoaiSP;
            this.maNCC = maNCC;
            this.hinhAnh = hinhAnh;
            this.donViTinh = donViTinh;
        }

        public override string ToString()
        {
            return $"{TenSP} - {GiaBan:C}";
        }
    }
}
