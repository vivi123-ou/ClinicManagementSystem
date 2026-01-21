using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }

        [Column("record_id")]
        public int RecordId { get; set; }

        [Column("total_amount")]
        [Precision(10, 2)]
        public decimal TotalAmount { get; set; } = 0;

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Active"; // Active, Completed, Cancelled

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("RecordId")]
        public virtual MedicalRecord MedicalRecord { get; set; }

        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}