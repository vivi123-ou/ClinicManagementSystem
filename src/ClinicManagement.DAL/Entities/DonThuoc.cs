using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("donthuoc")]
    public class DonThuoc
    {
        [Key]
        [Column("ma_don_thuoc")]
        public string MaDonThuoc { get; set; } = null!;

        [Column("ma_phieu_kham")]
        public string MaPhieuKham { get; set; } = null!;

        [Column("ngay_ke")]
        public DateTime NgayKe { get; set; } = DateTime.UtcNow;

        [Column("ghi_chu")]
        public string? GhiChu { get; set; }

        [ForeignKey("MaPhieuKham")]
        public PhieuKham PhieuKham { get; set; } = null!;

        public ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; } = new List<ChiTietDonThuoc>();
    }
}
