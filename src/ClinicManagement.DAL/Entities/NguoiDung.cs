using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("nguoidung")]
    public class NguoiDung
    {
        [Key]
        [Column("ma_nguoi_dung")]
        public string MaNguoiDung { get; set; } = null!;

        [Column("ten_dang_nhap")]
        public string TenDangNhap { get; set; } = null!;

        [Column("mat_khau")]
        public string MatKhau { get; set; } = null!;

        [Column("ho_ten")]
        public string HoTen { get; set; } = null!;

        [Column("vai_tro")]
        public string VaiTro { get; set; } = null!;

        [Column("trang_thai")]
        public bool TrangThai { get; set; } = true;

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }
}

