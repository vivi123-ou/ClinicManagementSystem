using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("phieukham")]
    public class PhieuKham
    {
        [Key]
        [Column("ma_phieu_kham")]
        public string MaPhieuKham { get; set; } = null!;

        [Column("ma_benh_nhan")]
        public string MaBenhNhan { get; set; } = null!;

        [Column("ma_bac_si")]
        public string MaBacSi { get; set; } = null!;

        [Column("ma_phong")]
        public string? MaPhong { get; set; }

        [Column("ngay_kham")]
        public DateTime NgayKham { get; set; } = DateTime.UtcNow;

        [Column("trieu_chung")]
        public string? TrieuChung { get; set; }

        [Column("chan_doan")]
        public string? ChanDoan { get; set; }

        [Column("huyet_ap")]
        public string? HuyetAp { get; set; }

        [Column("nhip_tim")]
        public int? NhipTim { get; set; }

        [Column("can_nang")]
        public decimal? CanNang { get; set; }

        [Column("chieu_cao")]
        public decimal? ChieuCao { get; set; }

        [Column("ghi_chu")]
        public string? GhiChu { get; set; }

        [Column("trang_thai")]
        public string TrangThai { get; set; } = "Chờ khám";

        [ForeignKey("MaBenhNhan")]
        public BenhNhan BenhNhan { get; set; } = null!;

        [ForeignKey("MaBacSi")]
        public NguoiDung BacSi { get; set; } = null!;

        public DonThuoc? DonThuoc { get; set; }
        public HoaDon? HoaDon { get; set; }
    }
}
