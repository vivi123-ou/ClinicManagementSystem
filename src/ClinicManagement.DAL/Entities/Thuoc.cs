using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("thuoc")]
    public class Thuoc
    {
        [Key]
        [Column("ma_thuoc")]
        public string MaThuoc { get; set; } = null!;

        [Column("ten_thuoc")]
        public string TenThuoc { get; set; } = null!;

        [Column("hoat_chat")]
        public string? HoatChat { get; set; }

        [Column("don_vi")]
        public string? DonVi { get; set; }

        [Column("don_gia")]
        public decimal DonGia { get; set; }

        [Column("so_luong_ton")]
        public int SoLuongTon { get; set; }

        [Column("han_su_dung")]
        public DateTime? HanSuDung { get; set; }

        [Column("nha_san_xuat")]
        public string? NhaSanXuat { get; set; }

        [Column("ghi_chu")]
        public string? GhiChu { get; set; }
    }
}
