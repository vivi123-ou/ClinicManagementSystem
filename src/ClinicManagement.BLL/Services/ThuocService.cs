using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.BLL.Services
{
    public class ThuocService : IThuocService
    {
        private readonly ClinicDbContext _context;

        public ThuocService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Thuoc>> GetAllAsync()
        {
            return await _context.Thuocs.ToListAsync();
        }

        public async Task<Thuoc?> GetByIdAsync(string id)
        {
            return await _context.Thuocs.FindAsync(id);
        }

        public async Task CreateAsync(Thuoc thuoc)
        {
            // Tự động sinh mã nếu cần, ở đây giả sử client gửi mã hoặc tự nhập
            _context.Thuocs.Add(thuoc);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id, Thuoc thuoc)
        {
            var existing = await _context.Thuocs.FindAsync(id);
            if (existing != null)
            {
                existing.TenThuoc = thuoc.TenThuoc;
                existing.DonGia = thuoc.DonGia;
                existing.SoLuongTon = thuoc.SoLuongTon;
                existing.DonVi = thuoc.DonVi;
                existing.HanSuDung = thuoc.HanSuDung;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            var item = await _context.Thuocs.FindAsync(id);
            if (item != null)
            {
                _context.Thuocs.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}