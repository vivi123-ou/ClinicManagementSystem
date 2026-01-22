using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using ClinicManagement.DAL.Entities;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu đăng nhập mới được dùng
    public class ThuocController : ControllerBase
    {
        private readonly IThuocService _service;
        public ThuocController(IThuocService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        [Authorize(Roles = "Admin,DuocSi")] // Chỉ Dược sĩ hoặc Admin được thêm thuốc
        public async Task<IActionResult> Create(Thuoc thuoc)
        {
            await _service.CreateAsync(thuoc);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}