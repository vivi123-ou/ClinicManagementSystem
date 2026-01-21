using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Column("medicine_name")]
        [Required]
        [MaxLength(100)]
        public string MedicineName { get; set; }

        [Column("category")]
        [MaxLength(50)]
        public string Category { get; set; }

        [Column("unit")]
        [MaxLength(20)]
        public string Unit { get; set; }

        [Column("unit_price")]
        [Required]
        [Precision(10, 2)]
        public decimal UnitPrice { get; set; }

        [Column("stock_quantity")]
        public int StockQuantity { get; set; } = 0;

        [Column("reorder_level")]
        public int ReorderLevel { get; set; } = 10;

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("manufacturer")]
        [MaxLength(100)]
        public string Manufacturer { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}