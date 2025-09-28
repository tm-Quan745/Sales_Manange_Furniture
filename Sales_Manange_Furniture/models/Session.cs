public static class Session
{
    // Lưu username hiện tại
    public static string USER_NAME { get; set; }

    // Có thể lưu thêm các thông tin khác của user nếu muốn
    public static int? MaNV { get; set; }
    public static string Role { get; set; }

    // Xóa session (khi logout)
    public static void Clear()
    {
        USER_NAME = null;
        MaNV = null;
        Role = null;
    }
}