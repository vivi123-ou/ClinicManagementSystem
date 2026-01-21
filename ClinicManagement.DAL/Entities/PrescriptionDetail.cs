using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("prescription_details")]
    public class PrescriptionDetail
    {
        [Key]
        [Column("detail_id")]
        public int DetailId { get; set; }

        [Column("prescription_id")]
        public int PrescriptionId { get; set; }

        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Column("quantity")]
        [Required]
        public int Quantity { get; set; }

        [Column("dosage")]
        [MaxLength(100)]
        public string Dosage { get; set; }

        [Column("frequency")]
        [MaxLength(100)]
        public string Frequency { get; set; }

        [Column("duration")]
        [MaxLength(50)]
        public string Duration { get; set; }

        [Column("instructions")]
        public string Instructions { get; set; }

        [Column("unit_price")]
        [Required]
        [Precision(10, 2)]
        public decimal UnitPrice { get; set; }

        // Computed property - matches database computed column
        [Column("subtotal")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Precision(10, 2)]
        public decimal? Subtotal { get; set; }

        // Navigation properties
        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}