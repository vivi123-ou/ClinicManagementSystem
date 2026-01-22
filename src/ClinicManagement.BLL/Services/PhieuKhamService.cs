using Microsoft.EntityFrameworkCore;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.BLL.Services
{
    public class PhieuKhamService : IPhieuKhamService
    {
        private readonly ClinicDbContext _context;

        public PhieuKhamService(ClinicDbContext context)
        {
            _context = context;
        }

        // Helper map Entity -> DTO
        private static PhieuKhamDetailDTO MapToDTO(PhieuKham pk)
        {
            return new PhieuKhamDetailDTO
            {
                MaPhieuKham = pk.MaPhieuKham,
                TenBenhNhan = pk.BenhNhan.HoTen,
                TenBacSi = pk.BacSi.HoTen,
                NgayKham = pk.NgayKham,
                TrieuChung = pk.TrieuChung,
                ChanDoan = pk.ChanDoan,
                TrangThai = pk.TrangThai
            };
        }

        public async Task<IEnumerable<PhieuKhamDetailDTO>> GetAllAsync()
        {
            var list = await _context.PhieuKhams
                .Include(p => p.BenhNhan)
                .Include(p => p.BacSi)
                .OrderByDescending(p => p.NgayKham)
                .ToListAsync();
            return list.Select(MapToDTO);
        }

        public async Task<IEnumerable<PhieuKhamDetailDTO>> GetByDoctorAsync(string maBacSi)
        {
            var list = await _context.PhieuKhams
                .Include(p => p.BenhNhan)
                .Include(p => p.BacSi)
                .Where(p => p.MaBacSi == maBacSi && p.TrangThai != "Hoàn thành")
                .OrderBy(p => p.NgayKham)
                .ToListAsync();
            return list.Select(MapToDTO);
        }

        public async Task<PhieuKhamDetailDTO?> GetByIdAsync(string id)
        {
            var pk = await _context.PhieuKhams
                .Include(p => p.BenhNhan)
                .Include(p => p.BacSi)
                .FirstOrDefaultAsync(p => p.MaPhieuKham == id);
            return pk == null ? null : MapToDTO(pk);
        }

        public async Task<string> CreateAsync(PhieuKhamCreateDTO dto)
        {
            // Tạo mã phiếu tự động: PK + timestamp
            var maPhieu = $"PK{DateTime.Now:yyyyMMddHHmmss}";

            var entity = new PhieuKham
            {
                MaPhieuKham = maPhieu,
                MaBenhNhan = dto.MaBenhNhan,
                MaBacSi = dto.MaBacSi,
                MaPhong = dto.MaPhong,
                TrieuChung = dto.TrieuChung,
                TrangThai = "Chờ khám",
                NgayKham = DateTime.UtcNow
            };

            _context.PhieuKhams.Add(entity);
            await _context.SaveChangesAsync();
            return maPhieu;
        }

        public async Task UpdateDiagnosisAsync(string id, ChanDoanDTO dto)
        {
            var pk = await _context.PhieuKhams.FindAsync(id);
            if (pk == null) throw new KeyNotFoundException("Không tìm thấy phiếu khám");

            pk.ChanDoan = dto.ChanDoan;
            pk.HuyetAp = dto.HuyetAp;
            pk.NhipTim = dto.NhipTim;
            pk.CanNang = dto.CanNang;
            pk.ChieuCao = dto.ChieuCao;
            pk.TrangThai = "Đang khám";

            await _context.SaveChangesAsync();
        }

        public async Task CompleteExamAsync(string id)
        {
            var pk = await _context.PhieuKhams.FindAsync(id);
            if (pk != null)
            {
                pk.TrangThai = "Đã khám xong"; // Chờ thanh toán
                await _context.SaveChangesAsync();
            }
        }
    }
}