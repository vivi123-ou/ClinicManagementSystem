namespace ClinicManagement.Common.DTOs
{
    public class ThuocItemDTO
    {
        public string MaThuoc { get; set; } = null!;
        public int SoLuong { get; set; }
        public string? LieuDung { get; set; }
    }

    public class DonThuocCreateDTO
    {
        public string MaPhieuKham { get; set; } = null!;
        public List<ThuocItemDTO> DanhSachThuoc { get; set; } = new();
      
    }

    public class ChiTietThuocDTO
    {
        public string MaThuoc { get; set; } = null!;
        public string TenThuoc { get; set; } = null!;
        public int SoLuong { get; set; }
        public string? LieuDung { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
