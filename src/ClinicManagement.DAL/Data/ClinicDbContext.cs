using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.DAL.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<BenhNhan> BenhNhans { get; set; }
        public DbSet<PhieuKham> PhieuKhams { get; set; }
        public DbSet<Thuoc> Thuocs { get; set; }
        public DbSet<DonThuoc> DonThuocs { get; set; }
        public DbSet<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<ChiTietSuDungDichVu> ChiTietSuDungDichVus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình precision cho decimal
            modelBuilder.Entity<Thuoc>()
                .Property(t => t.DonGia)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HoaDon>()
                .Property(h => h.TongTienDichVu)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HoaDon>()
                .Property(h => h.TongTienThuoc)
                .HasPrecision(12, 2);

            // Relationships
            modelBuilder.Entity<PhieuKham>()
                .HasOne(p => p.BenhNhan)
                .WithMany(b => b.PhieuKhams)
                .HasForeignKey(p => p.MaBenhNhan)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
