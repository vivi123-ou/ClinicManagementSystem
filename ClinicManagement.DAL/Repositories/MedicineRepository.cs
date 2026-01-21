using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.DAL.Repositories
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<Medicine> GetByIdAsync(int id);
        Task<Medicine> CreateAsync(Medicine medicine);
        Task<Medicine> UpdateAsync(Medicine medicine);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Medicine>> SearchByNameAsync(string name);
        Task<IEnumerable<Medicine>> GetLowStockAsync();
        Task<IEnumerable<Medicine>> GetExpiredAsync();
        Task<IEnumerable<Medicine>> GetByCategoryAsync(string category);
    }

    public class MedicineRepository : IMedicineRepository
    {
        private readonly ClinicDbContext _context;

        public MedicineRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicine>> GetAllAsync()
        {
            return await _context.Medicines
                .OrderBy(m => m.MedicineName)
                .ToListAsync();
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            return await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineId == id);
        }

        public async Task<Medicine> CreateAsync(Medicine medicine)
        {
            medicine.CreatedAt = DateTime.UtcNow;
            medicine.UpdatedAt = DateTime.UtcNow;
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();
            return medicine;
        }

        public async Task<Medicine> UpdateAsync(Medicine medicine)
        {
            medicine.UpdatedAt = DateTime.UtcNow;
            _context.Entry(medicine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicine;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicine = await GetByIdAsync(id);
            if (medicine == null) return false;

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Medicine>> SearchByNameAsync(string name)
        {
            return await _context.Medicines
                .Where(m => EF.Functions.ILike(m.MedicineName, $"%{name}%"))
                .OrderBy(m => m.MedicineName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GetLowStockAsync()
        {
            return await _context.Medicines
                .Where(m => m.StockQuantity <= m.ReorderLevel)
                .OrderBy(m => m.StockQuantity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GetExpiredAsync()
        {
            var today = DateTime.Today;
            return await _context.Medicines
                .Where(m => m.ExpiryDate.HasValue && m.ExpiryDate.Value < today)
                .OrderBy(m => m.ExpiryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GetByCategoryAsync(string category)
        {
            return await _context.Medicines
                .Where(m => EF.Functions.ILike(m.Category, $"%{category}%"))
                .OrderBy(m => m.MedicineName)
                .ToListAsync();
        }
    }
}