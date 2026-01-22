using Microsoft.EntityFrameworkCore;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.BLL.Services
{
    public interface IHoaDonService
    {
        Task CreateInvoiceAsync(string maPhieuKham, string nguoiThu); // Tạo hóa đơn từ phiếu khám
        Task PayAsync(string maHoaDon); // Thanh toán
    }

    public class HoaDonService : IHoaDonService
    {
        private readonly ClinicDbContext _context;

        public HoaDonService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task CreateInvoiceAsync(string maPhieuKham, string nguoiThu)
        {
            // 1. Tính tiền thuốc (nếu có đơn thuốc)
            decimal tienThuoc = 0;
            var donThuoc = await _context.DonThuocs
                .Include(d => d.ChiTietDonThuocs)
                .FirstOrDefaultAsync(d => d.MaPhieuKham == maPhieuKham);

            if (donThuoc != null)
            {
                tienThuoc = donThuoc.ChiTietDonThuocs.Sum(ct => ct.DonGia * ct.SoLuong);
            }

            // 2. Tiền dịch vụ (cố định ví dụ 150k)
            decimal tienDichVu = 150000;

            // 3. Tạo hóa đơn
            var hoaDon = new HoaDon
            {
                MaHoaDon = $"HD{DateTime.Now:MMddHHmm}",
                MaPhieuKham = maPhieuKham,
                TongTienThuoc = tienThuoc,
                TongTienDichVu = tienDichVu,
                TrangThai = "Chưa thanh toán",
                NguoiThu = nguoiThu,
                NgayTao = DateTime.UtcNow
            };

            _context.HoaDons.Add(hoaDon);

            // Cập nhật trạng thái phiếu khám
            var pk = await _context.PhieuKhams.FindAsync(maPhieuKham);
            if (pk != null) pk.TrangThai = "Chờ thanh toán";

            await _context.SaveChangesAsync();
        }

        public async Task PayAsync(string maHoaDon)
        {
            var hd = await _context.HoaDons.FindAsync(maHoaDon);
            if (hd != null)
            {
                hd.TrangThai = "Đã thanh toán";

                // Update phiếu khám thành hoàn thành
                var pk = await _context.PhieuKhams.FindAsync(hd.MaPhieuKham);
                if (pk != null) pk.TrangThai = "Hoàn thành";

                await _context.SaveChangesAsync();
            }
        }
    }
}