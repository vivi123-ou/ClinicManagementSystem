using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("chitietdonthuoc")]
    public class ChiTietDonThuoc
    {
        [Key]
        [Column("ma_chi_tiet")]
        public int MaChiTiet { get; set; }

        [Column("ma_don_thuoc")]
        public string MaDonThuoc { get; set; } = null!;

        [Column("ma_thuoc")]
        public string MaThuoc { get; set; } = null!;

        [Column("so_luong")]
        public int SoLuong { get; set; }

        [Column("lieu_dung")]
        public string? LieuDung { get; set; }

        [Column("don_gia")]
        public decimal DonGia { get; set; }

        [ForeignKey("MaDonThuoc")]
        public DonThuoc DonThuoc { get; set; } = null!;

        [ForeignKey("MaThuoc")]
        public Thuoc Thuoc { get; set; } = null!;
    }
}
