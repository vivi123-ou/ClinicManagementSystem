using AutoMapper;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities;
using ClinicManagement.DAL.Repositories;

namespace ClinicManagement.BLL.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDTO>> GetAllMedicinesAsync();
        Task<MedicineDTO> GetMedicineByIdAsync(int id);
        Task<MedicineDTO> CreateMedicineAsync(CreateMedicineDTO dto);
        Task<MedicineDTO> UpdateMedicineAsync(int id, UpdateMedicineDTO dto);
        Task<bool> DeleteMedicineAsync(int id);
        Task<IEnumerable<MedicineDTO>> SearchMedicinesByNameAsync(string name);
        Task<IEnumerable<MedicineDTO>> GetLowStockMedicinesAsync();
        Task<IEnumerable<MedicineDTO>> GetExpiredMedicinesAsync();
        Task<IEnumerable<MedicineDTO>> GetMedicinesByCategoryAsync(string category);
    }

    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;
        private readonly IMapper _mapper;

        public MedicineService(IMedicineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicineDTO>> GetAllMedicinesAsync()
        {
            var medicines = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }

        public async Task<MedicineDTO> GetMedicineByIdAsync(int id)
        {
            var medicine = await _repository.GetByIdAsync(id);
            if (medicine == null)
                throw new KeyNotFoundException($"Medicine with ID {id} not found");

            return _mapper.Map<MedicineDTO>(medicine);
        }

        public async Task<MedicineDTO> CreateMedicineAsync(CreateMedicineDTO dto)
        {
            var medicine = _mapper.Map<Medicine>(dto);
            var created = await _repository.CreateAsync(medicine);
            return _mapper.Map<MedicineDTO>(created);
        }

        public async Task<MedicineDTO> UpdateMedicineAsync(int id, UpdateMedicineDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Medicine with ID {id} not found");

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);
            return _mapper.Map<MedicineDTO>(updated);
        }

        public async Task<bool> DeleteMedicineAsync(int id)
        {
            var exists = await _repository.GetByIdAsync(id);
            if (exists == null)
                throw new KeyNotFoundException($"Medicine with ID {id} not found");

            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MedicineDTO>> SearchMedicinesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await GetAllMedicinesAsync();

            var medicines = await _repository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }

        public async Task<IEnumerable<MedicineDTO>> GetLowStockMedicinesAsync()
        {
            var medicines = await _repository.GetLowStockAsync();
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }

        public async Task<IEnumerable<MedicineDTO>> GetExpiredMedicinesAsync()
        {
            var medicines = await _repository.GetExpiredAsync();
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }

        public async Task<IEnumerable<MedicineDTO>> GetMedicinesByCategoryAsync(string category)
        {
            var medicines = await _repository.GetByCategoryAsync(category);
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }
    }
}