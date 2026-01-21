using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using ClinicManagement.Common.DTOs;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(IDoctorService doctorService, ILogger<DoctorsController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        /// <summary>
        /// Get all doctors
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all doctors");
                return StatusCode(500, new { message = "An error occurred while retrieving doctors" });
            }
        }

        /// <summary>
        /// Get doctor by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DoctorDTO>> GetDoctor(int id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(id);
                return Ok(doctor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting doctor {DoctorId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the doctor" });
            }
        }

        /// <summary>
        /// Search doctors by name
        /// </summary>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> SearchDoctors([FromQuery] string name)
        {
            try
            {
                var doctors = await _doctorService.SearchDoctorsByNameAsync(name);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching doctors");
                return StatusCode(500, new { message = "An error occurred while searching doctors" });
            }
        }

        /// <summary>
        /// Get doctors by specialty
        /// </summary>
        [HttpGet("specialty/{specialty}")]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctorsBySpecialty(string specialty)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpecialtyAsync(specialty);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting doctors by specialty");
                return StatusCode(500, new { message = "An error occurred while retrieving doctors" });
            }
        }

        /// <summary>
        /// Create a new doctor
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DoctorDTO>> CreateDoctor([FromBody] CreateDoctorDTO dto)
        {
            try
            {
                var created = await _doctorService.CreateDoctorAsync(dto);
                return CreatedAtAction(nameof(GetDoctor), new { id = created.DoctorId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating doctor");
                return StatusCode(500, new { message = "An error occurred while creating the doctor" });
            }
        }

        /// <summary>
        /// Update doctor information
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DoctorDTO>> UpdateDoctor(int id, [FromBody] UpdateDoctorDTO dto)
        {
            try
            {
                var updated = await _doctorService.UpdateDoctorAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating doctor {DoctorId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the doctor" });
            }
        }

        /// <summary>
        /// Delete a doctor
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                await _doctorService.DeleteDoctorAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting doctor {DoctorId}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the doctor" });
            }
        }
    }
}