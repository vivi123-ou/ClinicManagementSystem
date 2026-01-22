using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("hoadon")]
    public class HoaDon
    {
        [Key]
        [Column("ma_hoa_don")]
        public string MaHoaDon { get; set; } = null!;

        [Column("ma_phieu_kham")]
        public string MaPhieuKham { get; set; } = null!;

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;

        [Column("tong_tien_dich_vu")]
        public decimal TongTienDichVu { get; set; }

        [Column("tong_tien_thuoc")]
        public decimal TongTienThuoc { get; set; }

        [Column("trang_thai")]
        public string TrangThai { get; set; } = "Chưa thanh toán";

        [Column("phuong_thuc_thanh_toan")]
        public string? PhuongThucThanhToan { get; set; }

        [Column("nguoi_thu")]
        public string? NguoiThu { get; set; }

        [ForeignKey("MaPhieuKham")]
        public PhieuKham PhieuKham { get; set; } = null!;
    }
}
