using System;

namespace Sales_Manange_Furniture.models
{
    public class KhuyenMai
    {
        public int MaKM { get; set; }
        public string TenKM { get; set; }
        public string LoaiKM { get; set; }      // "PERCENT" hoặc "AMOUNT"
        public decimal GiaTriKM { get; set; }   // % hoặc số tiền giảm
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool TrangThai { get; set; }     // true = đang áp dụng, false = hết hạn

        public KhuyenMai() { }

        public KhuyenMai(int maKM, string tenKM, string loaiKM, decimal giaTriKM,
                         string moTa, DateTime ngayBD, DateTime ngayKT, bool trangThai)
        {
            MaKM = maKM;
            TenKM = tenKM;
            LoaiKM = loaiKM;
            GiaTriKM = giaTriKM;
            MoTa = moTa;
            NgayBatDau = ngayBD;
            NgayKetThuc = ngayKT;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{TenKM} ({LoaiKM} - {GiaTriKM}) [{NgayBatDau:dd/MM/yyyy} → {NgayKetThuc:dd/MM/yyyy}]";
        }
    }
}
