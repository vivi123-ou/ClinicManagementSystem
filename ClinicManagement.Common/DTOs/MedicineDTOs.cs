using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Common.DTOs
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Computed property
        public bool IsLowStock => StockQuantity <= ReorderLevel;
        public bool IsExpired => ExpiryDate.HasValue && ExpiryDate.Value < DateTime.Today;
    }

    public class CreateMedicineDTO
    {
        [Required(ErrorMessage = "Medicine name is required")]
        [StringLength(100)]
        public string MedicineName { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; } = 10;

        public DateTime? ExpiryDate { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        public string Description { get; set; }
    }

    public class UpdateMedicineDTO
    {
        [Required]
        [StringLength(100)]
        public string MedicineName { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        public string Description { get; set; }
    }
}