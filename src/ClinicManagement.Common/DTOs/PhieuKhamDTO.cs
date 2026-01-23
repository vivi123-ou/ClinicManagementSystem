namespace ClinicManagement.Common.DTOs
{
    public class PhieuKhamCreateDTO
    {
        public string MaBenhNhan { get; set; } = null!;
        public string MaBacSi { get; set; } = null!;
        public string? MaPhong { get; set; }
        public string? TrieuChung { get; set; }
    }

    public class PhieuKhamDetailDTO
    {
        public string MaPhieuKham { get; set; } = null!;
        public string TenBenhNhan { get; set; } = null!;
        public string TenBacSi { get; set; } = null!;
        public DateTime NgayKham { get; set; }
        public string? TrieuChung { get; set; }
        public string? ChanDoan { get; set; }
        public string TrangThai { get; set; } = null!;
        public List<KetQuaDichVuViewDTO> DanhSachDichVuDaLam { get; set; } = new();
    }

    public class ChanDoanDTO
    {
        public string? ChanDoan { get; set; }
        public string? HuyetAp { get; set; }
        public int? NhipTim { get; set; }
        public decimal? CanNang { get; set; }
        public decimal? ChieuCao { get; set; }
    }
}
