public class GioHang
{
    public int MaSP { get; set; }
    public string TenSP { get; set; }
    public int MaKM { get; set; }
    public decimal GiaTriApDung { get; set; } // Giá trị khuyến mãi (có thể % hoặc số tiền)
    public string KieuKM { get; set; }        // "PERCENT" hoặc "FIXED"
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal TongTien { get; set; }     // chỉ = DonGia * SL
    public decimal ThueVAT { get; set; }

    public GioHang() { }
}
