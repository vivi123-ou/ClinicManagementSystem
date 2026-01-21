using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicManagement.BLL.Services;
using ClinicManagement.Common.DTOs;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly ILogger<MedicinesController> _logger;

        public MedicinesController(IMedicineService medicineService, ILogger<MedicinesController> logger)
        {
            _medicineService = medicineService;
            _logger = logger;
        }

        /// <summary>
        /// Get all medicines
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicineDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAllMedicines()
        {
            try
            {
                var medicines = await _medicineService.GetAllMedicinesAsync();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all medicines");
                return StatusCode(500, new { message = "An error occurred while retrieving medicines" });
            }
        }

        /// <summary>
        /// Get medicine by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicineDTO>> GetMedicine(int id)
        {
            try
            {
                var medicine = await _medicineService.GetMedicineByIdAsync(id);
                return Ok(medicine);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Medicine with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting medicine {MedicineId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the medicine" });
            }
        }

        /// <summary>
        /// Search medicines by name
        /// </summary>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicineDTO>>> SearchMedicines([FromQuery] string name)
        {
            try
            {
                var medicines = await _medicineService.SearchMedicinesByNameAsync(name);
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching medicines");
                return StatusCode(500, new { message = "An error occurred while searching medicines" });
            }
        }

        /// <summary>
        /// Get low stock medicines
        /// </summary>
        [HttpGet("low-stock")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetLowStockMedicines()
        {
            try
            {
                var medicines = await _medicineService.GetLowStockMedicinesAsync();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting low stock medicines");
                return StatusCode(500, new { message = "An error occurred while retrieving medicines" });
            }
        }

        /// <summary>
        /// Get expired medicines
        /// </summary>
        [HttpGet("expired")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetExpiredMedicines()
        {
            try
            {
                var medicines = await _medicineService.GetExpiredMedicinesAsync();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting expired medicines");
                return StatusCode(500, new { message = "An error occurred while retrieving medicines" });
            }
        }

        /// <summary>
        /// Get medicines by category
        /// </summary>
        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetMedicinesByCategory(string category)
        {
            try
            {
                var medicines = await _medicineService.GetMedicinesByCategoryAsync(category);
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting medicines by category");
                return StatusCode(500, new { message = "An error occurred while retrieving medicines" });
            }
        }

        /// <summary>
        /// Create a new medicine
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        [ProducesResponseType(typeof(MedicineDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicineDTO>> CreateMedicine([FromBody] CreateMedicineDTO dto)
        {
            try
            {
                var created = await _medicineService.CreateMedicineAsync(dto);
                return CreatedAtAction(nameof(GetMedicine), new { id = created.MedicineId }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating medicine");
                return StatusCode(500, new { message = "An error occurred while creating the medicine" });
            }
        }

        /// <summary>
        /// Update medicine information
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        [ProducesResponseType(typeof(MedicineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicineDTO>> UpdateMedicine(int id, [FromBody] UpdateMedicineDTO dto)
        {
            try
            {
                var updated = await _medicineService.UpdateMedicineAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Medicine with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating medicine {MedicineId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the medicine" });
            }
        }

        /// <summary>
        /// Delete a medicine
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            try
            {
                await _medicineService.DeleteMedicineAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Medicine with ID {id} not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting medicine {MedicineId}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the medicine" });
            }
        }
    }
}