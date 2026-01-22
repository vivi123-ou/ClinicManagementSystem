using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("benhnhan")]
    public class BenhNhan
    {
        [Key]
        [Column("ma_benh_nhan")]
        public string MaBenhNhan { get; set; } = null!;

        [Column("ho_ten")]
        public string HoTen { get; set; } = null!;

        [Column("ngay_sinh")]
        public DateTime? NgaySinh { get; set; }

        [Column("gioi_tinh")]
        public string? GioiTinh { get; set; }

        [Column("so_dien_thoai")]
        public string? SoDienThoai { get; set; }

        [Column("dia_chi")]
        public string? DiaChi { get; set; }

        [Column("cmnd")]
        public string? CMND { get; set; }

        [Column("ngay_dang_ky")]
        public DateTime NgayDangKy { get; set; } = DateTime.UtcNow;

        public ICollection<PhieuKham> PhieuKhams { get; set; } = new List<PhieuKham>();
    }
}
