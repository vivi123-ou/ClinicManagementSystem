using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using ClinicManagement.Common.DTOs;
using ClinicManagement.BLL.Service;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Require authentication for all endpoints
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>List of all patients</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatientDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all patients");
                return StatusCode(500, new { message = "An error occurred while retrieving patients" });
            }
        }

        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>Patient details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);
                return Ok(patient);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Patient with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting patient {PatientId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the patient" });
            }
        }

        /// <summary>
        /// Search patients by name
        /// </summary>
        /// <param name="name">Search term</param>
        /// <returns>List of matching patients</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<PatientDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> SearchPatients([FromQuery] string name)
        {
            try
            {
                var patients = await _patientService.SearchPatientsByNameAsync(name);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching patients with term {SearchTerm}", name);
                return StatusCode(500, new { message = "An error occurred while searching patients" });
            }
        }

        /// <summary>
        /// Create a new patient
        /// </summary>
        /// <param name="dto">Patient data</param>
        /// <returns>Created patient</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Receptionist,Doctor")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatientDTO>> CreatePatient([FromBody] CreatePatientDTO dto)
        {
            try
            {
                var created = await _patientService.CreatePatientAsync(dto);
                return CreatedAtAction(nameof(GetPatient), new { id = created.PatientId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating patient");
                return StatusCode(500, new { message = "An error occurred while creating the patient" });
            }
        }

        /// <summary>
        /// Update patient information
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <param name="dto">Updated patient data</param>
        /// <returns>Updated patient</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Receptionist,Doctor")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientDTO>> UpdatePatient(int id, [FromBody] UpdatePatientDTO dto)
        {
            try
            {
                var updated = await _patientService.UpdatePatientAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Patient with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating patient {PatientId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the patient" });
            }
        }

        /// <summary>
        /// Delete a patient
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientService.DeletePatientAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Patient with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting patient {PatientId}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the patient" });
            }
        }
    }
}