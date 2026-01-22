namespace ClinicManagement.Common.DTOs
{
    public class HoaDonDTO
    {
        public string MaHoaDon { get; set; } = null!;
        public string MaPhieuKham { get; set; } = null!;
        public string TenBenhNhan { get; set; } = null!;
        public DateTime NgayTao { get; set; }
        public decimal TongTienDichVu { get; set; }
        public decimal TongTienThuoc { get; set; }
        public decimal TongCong => TongTienDichVu + TongTienThuoc;
        public string TrangThai { get; set; } = null!;
    }

    public class ThanhToanRequest
    {
        public string PhuongThucThanhToan { get; set; } = "Tiền mặt";
    }
}
