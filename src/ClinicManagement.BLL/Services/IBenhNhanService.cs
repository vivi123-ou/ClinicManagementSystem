using ClinicManagement.Common.DTOs;

namespace ClinicManagement.BLL.Services
{
    public interface IBenhNhanService
    {
        Task<IEnumerable<BenhNhanDTO>> GetAllAsync();
        Task<BenhNhanDTO?> GetByIdAsync(string id);
        Task<BenhNhanDTO> CreateAsync(BenhNhanDTO dto);
        Task UpdateAsync(string id, BenhNhanDTO dto);
        Task DeleteAsync(string id);
        Task<IEnumerable<BenhNhanDTO>> SearchAsync(string keyword);
    }
}
