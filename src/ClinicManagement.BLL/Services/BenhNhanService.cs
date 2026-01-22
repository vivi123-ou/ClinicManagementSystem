using Microsoft.EntityFrameworkCore;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.BLL.Services
{
    public class BenhNhanService : IBenhNhanService
    {
        private readonly ClinicDbContext _context;

        public BenhNhanService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BenhNhanDTO>> GetAllAsync()
        {
            return await _context.BenhNhans
                .Select(b => new BenhNhanDTO
                {
                    MaBenhNhan = b.MaBenhNhan,
                    HoTen = b.HoTen,
                    NgaySinh = b.NgaySinh,
                    GioiTinh = b.GioiTinh,
                    SoDienThoai = b.SoDienThoai,
                    DiaChi = b.DiaChi,
                    CMND = b.CMND
                })
            .ToListAsync();
        }

        public async Task<BenhNhanDTO?> GetByIdAsync(string id)
        {
            var bn = await _context.BenhNhans.FindAsync(id);
            if (bn == null) return null;

            return new BenhNhanDTO
            {
                MaBenhNhan = bn.MaBenhNhan,
                HoTen = bn.HoTen,
                NgaySinh = bn.NgaySinh,
                GioiTinh = bn.GioiTinh,
                SoDienThoai = bn.SoDienThoai,
                DiaChi = bn.DiaChi,
                CMND = bn.CMND
            };
        }

        public async Task<BenhNhanDTO> CreateAsync(BenhNhanDTO dto)
        {
            var lastBN = await _context.BenhNhans
                .OrderByDescending(b => b.MaBenhNhan)
                .FirstOrDefaultAsync();

            int nextNum = 1;
            if (lastBN != null)
            {
                var numPart = lastBN.MaBenhNhan.Substring(2);
                nextNum = int.Parse(numPart) + 1;
            }

            var newMa = $"BN{nextNum:D3}";

            var benhNhan = new BenhNhan
            {
                MaBenhNhan = newMa,
                HoTen = dto.HoTen,
                NgaySinh = dto.NgaySinh,
                GioiTinh = dto.GioiTinh,
                SoDienThoai = dto.SoDienThoai,
                DiaChi = dto.DiaChi,
                CMND = dto.CMND
            };

            _context.BenhNhans.Add(benhNhan);
            await _context.SaveChangesAsync();

            dto.MaBenhNhan = newMa;
            return dto;
        }

        public async Task UpdateAsync(string id, BenhNhanDTO dto)
        {
            var bn = await _context.BenhNhans.FindAsync(id);
            if (bn == null)
                throw new KeyNotFoundException("Không tìm thấy bệnh nhân");

            bn.HoTen = dto.HoTen;
            bn.NgaySinh = dto.NgaySinh;
            bn.GioiTinh = dto.GioiTinh;
            bn.SoDienThoai = dto.SoDienThoai;
            bn.DiaChi = dto.DiaChi;
            bn.CMND = dto.CMND;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var bn = await _context.BenhNhans
                .Include(b => b.PhieuKhams)
                .FirstOrDefaultAsync(b => b.MaBenhNhan == id);

            if (bn == null)
                throw new KeyNotFoundException("Không tìm thấy bệnh nhân");

            if (bn.PhieuKhams.Any())
                throw new InvalidOperationException("Không thể xóa bệnh nhân đã có lịch sử khám");

            _context.BenhNhans.Remove(bn);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BenhNhanDTO>> SearchAsync(string keyword)
        {
            var query = _context.BenhNhans.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(b =>
                    b.HoTen.Contains(keyword) ||
                    b.SoDienThoai.Contains(keyword) ||
                    b.MaBenhNhan.Contains(keyword));
            }

            return await query
                .Select(b => new BenhNhanDTO
                {
                    MaBenhNhan = b.MaBenhNhan,
                    HoTen = b.HoTen,
                    NgaySinh = b.NgaySinh,
                    GioiTinh = b.GioiTinh,
                    SoDienThoai = b.SoDienThoai,
                    DiaChi = b.DiaChi,
                    CMND = b.CMND
                })
                .ToListAsync();
        }
    }
}