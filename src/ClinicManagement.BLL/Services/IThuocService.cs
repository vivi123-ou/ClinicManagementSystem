using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities; // Dùng tạm Entity cho nhanh, hoặc map DTO nếu muốn chuẩn 100%

namespace ClinicManagement.BLL.Services
{
    public interface IThuocService
    {
        Task<IEnumerable<Thuoc>> GetAllAsync();
        Task<Thuoc?> GetByIdAsync(string id);
        Task CreateAsync(Thuoc thuoc);
        Task UpdateAsync(string id, Thuoc thuoc);
        Task DeleteAsync(string id);
    }
}