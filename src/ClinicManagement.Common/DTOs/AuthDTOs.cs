namespace ClinicManagement.Common.DTOs
{
    // DTO cho yêu cầu đăng nhập
    public class LoginRequestDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    // DTO cho kết quả trả về khi đăng nhập thành công
    public class LoginResponseDTO
    {
        public string Token { get; set; } = null!;
        public string MaNguoiDung { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string VaiTro { get; set; } = null!;
    }
    public class BacSiDTO
    {
        public string MaNguoiDung { get; set; } = null!;
        public string HoTen { get; set; } = null!;
    }
}