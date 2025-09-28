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

        // --- Thông tin khuyến mãi tham chiếu ---
        public string DanhSachKM { get; set; }       // có thể null nếu SP ko có KM


        // Đơn giá sau khi áp dụng khuyến mãi
        
    }
}
