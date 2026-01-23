using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.DAL.Data; // Nơi chứa ClinicDbContext
using ClinicManagement.Common.DTOs; // Nơi chứa BacSiDTO

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly ClinicDbContext _context;

        // Inject Database vào để dùng
        public NguoiDungController(ClinicDbContext context)
        {
            _context = context;
        }

        // API: Lấy danh sách bác sĩ
        // Đường dẫn: GET /api/NguoiDung/get-bac-si
        [HttpGet("get-bac-si")]
        [Authorize] // Yêu cầu phải đăng nhập mới được gọi
        public async Task<IActionResult> GetDanhSachBacSi()
        {
            // Lấy tất cả user có vai trò là "BacSi"
            // Lưu ý: Code này sẽ lấy cả chữ hoa lẫn thường (BacSi hoặc bacsi) để đảm bảo không sót
            var list = await _context.NguoiDungs
                .Where(u => u.VaiTro == "BacSi" || u.VaiTro == "bacsi")
                .Select(u => new BacSiDTO
                {
                    MaNguoiDung = u.MaNguoiDung,
                    HoTen = u.HoTen
                })
                .ToListAsync();

            return Ok(list);
        }
    }
}