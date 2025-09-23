namespace Sales_Manange_Furniture.models
{
    public class ChiTietKhuyenMai
    {
        public int MaCTKM { get; set; }
        public int MaKM { get; set; }
        public string TenKM { get; set; }   // lấy từ bảng KhuyenMai
        public int MaSP { get; set; }
        public string TenSP { get; set; }   // lấy từ bảng SanPham
        public string KieuKM { get; set; }
        public decimal GiaTriApDung { get; set; }

        // Thêm thuộc tính tham chiếu (optional, để dễ show trong form DataGridView)
       
       

        public ChiTietKhuyenMai() { }

        public ChiTietKhuyenMai(int maCTKM, int maKM, int maSP, string kieuKM, decimal giaTri)
        {
            MaCTKM = maCTKM;
            MaKM = maKM;
            MaSP = maSP;
            KieuKM = kieuKM;
            GiaTriApDung = giaTri;
        }

        public override string ToString()
        {
            return $"CTKM#{MaCTKM} - KM:{MaKM}, SP:{MaSP}, Kiểu KM: {KieuKM}, Giá trị: {GiaTriApDung}";
        }
    }
}
