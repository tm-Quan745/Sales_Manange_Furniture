using System;

namespace Sales_Manage_Furniture.models
{
    public class ChiTietHDB
    {
        public int MaHDB { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; } // Tên sản phẩm
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        // Thành tiền gốc (chưa KM)
        public decimal ThanhTien => SoLuong * DonGia;

        // --- Thông tin khuyến mãi tham chiếu ---
        public int? MaKM { get; set; }       // có thể null nếu SP ko có KM
        public string TenKM { get; set; }    // Tên khuyến mãi
        public string LoaiKM { get; set; }   // "PERCENT" hoặc "AMOUNT"
        public decimal GiaTriKM { get; set; } // % giảm hoặc số tiền giảm

        // Đơn giá sau khi áp dụng khuyến mãi
        public decimal DonGiaSauKM
        {
            get
            {
                if (LoaiKM == "PERCENT")
                    return DonGia * (1 - GiaTriKM / 100);
                else if (LoaiKM == "AMOUNT")
                    return DonGia - GiaTriKM > 0 ? DonGia - GiaTriKM : 0;
                return DonGia;
            }
        }

        // Thành tiền sau khuyến mãi
        public decimal ThanhTienSauKM => SoLuong * DonGiaSauKM;

        public ChiTietHDB() { }

        public ChiTietHDB(int maHDB, int maSP, int soLuong, decimal donGia)
        {
            MaHDB = maHDB;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public override string ToString()
        {
            return $"SP#{MaSP} - SL: {SoLuong} - Giá gốc: {DonGia:C} - KM: {TenKM} - Giá sau KM: {DonGiaSauKM:C} - Thành tiền: {ThanhTienSauKM:C}";
        }
    }
}
