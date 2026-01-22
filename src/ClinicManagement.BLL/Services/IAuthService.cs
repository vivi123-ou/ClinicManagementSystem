using ClinicManagement.Common.DTOs;

namespace ClinicManagement.BLL.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request);
    }
}
