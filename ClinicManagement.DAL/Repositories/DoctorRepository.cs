using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.DAL.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<Doctor> UpdateAsync(Doctor doctor);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Doctor>> SearchByNameAsync(string name);
        Task<IEnumerable<Doctor>> GetBySpecialtyAsync(string specialty);
        Task<bool> ExistsByLicenseNumberAsync(string licenseNumber);
    }

    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbContext _context;

        public DoctorRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors
                .Include(d => d.User)
                .OrderBy(d => d.FullName)
                .ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Appointments)
                .FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            doctor.CreatedAt = DateTime.UtcNow;
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateAsync(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Doctor>> SearchByNameAsync(string name)
        {
            return await _context.Doctors
                .Where(d => EF.Functions.ILike(d.FullName, $"%{name}%"))
                .OrderBy(d => d.FullName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetBySpecialtyAsync(string specialty)
        {
            return await _context.Doctors
                .Where(d => EF.Functions.ILike(d.Specialty, $"%{specialty}%"))
                .OrderBy(d => d.FullName)
                .ToListAsync();
        }

        public async Task<bool> ExistsByLicenseNumberAsync(string licenseNumber)
        {
            return await _context.Doctors
                .AnyAsync(d => d.LicenseNumber == licenseNumber);
        }
    }
}