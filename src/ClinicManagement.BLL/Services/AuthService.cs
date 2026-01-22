using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Data;
using ClinicManagement.BLL.Helpers;

namespace ClinicManagement.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ClinicDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ClinicDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            var user = await _context.NguoiDungs
                .FirstOrDefaultAsync(u => u.TenDangNhap == request.Username);

            if (user == null || user.MatKhau != request.Password)
                return null;

            if (!user.TrangThai)
                return null;

            var token = JwtHelper.GenerateToken(user, _configuration);

            return new LoginResponseDTO
            {
                Token = token,
                MaNguoiDung = user.MaNguoiDung,
                HoTen = user.HoTen,
                VaiTro = user.VaiTro
            };
        }
    }
}
