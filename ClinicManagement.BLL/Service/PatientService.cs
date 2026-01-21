using AutoMapper;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities;
using ClinicManagement.DAL.Repositories;

namespace ClinicManagement.BLL.Service
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
        Task<PatientDTO> GetPatientByIdAsync(int id);
        Task<PatientDTO> CreatePatientAsync(CreatePatientDTO dto);
        Task<PatientDTO> UpdatePatientAsync(int id, UpdatePatientDTO dto);
        Task<bool> DeletePatientAsync(int id);
        Task<IEnumerable<PatientDTO>> SearchPatientsByNameAsync(string name);
    }

    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public async Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null)
                throw new KeyNotFoundException($"Patient with ID {id} not found");

            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task<PatientDTO> CreatePatientAsync(CreatePatientDTO dto)
        {
            // Validate identity card uniqueness
            if (!string.IsNullOrEmpty(dto.IdentityCard))
            {
                var exists = await _repository.ExistsByIdentityCardAsync(dto.IdentityCard);
                if (exists)
                    throw new InvalidOperationException("A patient with this identity card already exists");
            }

            var patient = _mapper.Map<Patient>(dto);
            var created = await _repository.CreateAsync(patient);
            return _mapper.Map<PatientDTO>(created);
        }

        public async Task<PatientDTO> UpdatePatientAsync(int id, UpdatePatientDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Patient with ID {id} not found");

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);
            return _mapper.Map<PatientDTO>(updated);
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var exists = await _repository.GetByIdAsync(id);
            if (exists == null)
                throw new KeyNotFoundException($"Patient with ID {id} not found");

            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PatientDTO>> SearchPatientsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await GetAllPatientsAsync();

            var patients = await _repository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}