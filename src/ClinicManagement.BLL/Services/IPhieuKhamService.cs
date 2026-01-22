using ClinicManagement.Common.DTOs;

namespace ClinicManagement.BLL.Services
{
    public interface IPhieuKhamService
    {
        Task<IEnumerable<PhieuKhamDetailDTO>> GetAllAsync(); // Lấy tất cả
        Task<IEnumerable<PhieuKhamDetailDTO>> GetByDoctorAsync(string maBacSi); // Lấy danh sách chờ của bác sĩ
        Task<PhieuKhamDetailDTO?> GetByIdAsync(string id);
        Task<string> CreateAsync(PhieuKhamCreateDTO dto); // Trả về Mã phiếu
        Task UpdateDiagnosisAsync(string id, ChanDoanDTO dto); // Bác sĩ khám
        Task CompleteExamAsync(string id); // Kết thúc khám
    }
}