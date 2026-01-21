using AutoMapper;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities;
using ClinicManagement.DAL.Repositories;

namespace ClinicManagement.BLL.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<DoctorDTO> GetDoctorByIdAsync(int id);
        Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO dto);
        Task<DoctorDTO> UpdateDoctorAsync(int id, UpdateDoctorDTO dto);
        Task<bool> DeleteDoctorAsync(int id);
        Task<IEnumerable<DoctorDTO>> SearchDoctorsByNameAsync(string name);
        Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecialtyAsync(string specialty);
    }

    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO dto)
        {
            // Validate license number uniqueness
            if (!string.IsNullOrEmpty(dto.LicenseNumber))
            {
                var exists = await _repository.ExistsByLicenseNumberAsync(dto.LicenseNumber);
                if (exists)
                    throw new InvalidOperationException("A doctor with this license number already exists");
            }

            var doctor = _mapper.Map<Doctor>(dto);
            var created = await _repository.CreateAsync(doctor);
            return _mapper.Map<DoctorDTO>(created);
        }

        public async Task<DoctorDTO> UpdateDoctorAsync(int id, UpdateDoctorDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);
            return _mapper.Map<DoctorDTO>(updated);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var exists = await _repository.GetByIdAsync(id);
            if (exists == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DoctorDTO>> SearchDoctorsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await GetAllDoctorsAsync();

            var doctors = await _repository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecialtyAsync(string specialty)
        {
            var doctors = await _repository.GetBySpecialtyAsync(specialty);
            return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
        }
    }
}