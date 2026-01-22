namespace ClinicManagement.Common.DTOs
{
    public class BenhNhanDTO
    {
        public string MaBenhNhan { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? CMND { get; set; }
    }
}