using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using System.Security.Claims;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService _service;
        public HoaDonController(IHoaDonService service) => _service = service;

        [HttpPost("create")]
        [Authorize(Roles = "LeTan,ThuNgan")]
        public async Task<IActionResult> CreateInvoice(string maPhieuKham)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "system";
            await _service.CreateInvoiceAsync(maPhieuKham, userId);
            return Ok(new { message = "Đã tạo hóa đơn" });
        }

        [HttpPost("{id}/pay")]
        [Authorize(Roles = "LeTan,ThuNgan")]
        public async Task<IActionResult> Pay(string id)
        {
            await _service.PayAsync(id);
            return Ok(new { message = "Thanh toán thành công" });
        }
    }
}