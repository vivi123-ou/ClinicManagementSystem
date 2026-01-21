using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Data;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.DAL.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> CreateAsync(Patient patient);
        Task<Patient> UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Patient>> SearchByNameAsync(string name);
        Task<bool> ExistsByIdentityCardAsync(string identityCard);
    }

    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDbContext _context;

        public PatientRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.MedicalRecords)
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            patient.CreatedAt = DateTime.UtcNow;
            patient.UpdatedAt = DateTime.UtcNow;

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            patient.UpdatedAt = DateTime.UtcNow;

            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await GetByIdAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Patient>> SearchByNameAsync(string name)
        {
            return await _context.Patients
                .Where(p => EF.Functions.ILike(p.FullName, $"%{name}%"))
                .OrderBy(p => p.FullName)
                .ToListAsync();
        }

        public async Task<bool> ExistsByIdentityCardAsync(string identityCard)
        {
            return await _context.Patients
                .AnyAsync(p => p.IdentityCard == identityCard);
        }
    }
}