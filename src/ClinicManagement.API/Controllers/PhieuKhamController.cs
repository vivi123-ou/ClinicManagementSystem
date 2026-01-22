using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using ClinicManagement.Common.DTOs;
using System.Security.Claims;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhieuKhamController : ControllerBase
    {
        private readonly IPhieuKhamService _service;
        public PhieuKhamController(IPhieuKhamService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        // Lấy danh sách bệnh nhân chờ khám của riêng bác sĩ đang đăng nhập
        [HttpGet("my-patients")]
        [Authorize(Roles = "BacSi")]
        public async Task<IActionResult> GetMyPatients()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            return Ok(await _service.GetByDoctorAsync(userId));
        }

        [HttpPost]
        [Authorize(Roles = "LeTan,Admin")] // Lễ tân tạo phiếu
        public async Task<IActionResult> Create(PhieuKhamCreateDTO dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { MaPhieu = id });
        }

        [HttpPut("{id}/diagnosis")]
        [Authorize(Roles = "BacSi")] // Bác sĩ chẩn đoán
        public async Task<IActionResult> UpdateDiagnosis(string id, ChanDoanDTO dto)
        {
            try
            {
                await _service.UpdateDiagnosisAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException) { return NotFound(); }
        }

        [HttpPost("{id}/complete")]
        [Authorize(Roles = "BacSi")]
        public async Task<IActionResult> Complete(string id)
        {
            await _service.CompleteExamAsync(id);
            return Ok();
        }
    }
}