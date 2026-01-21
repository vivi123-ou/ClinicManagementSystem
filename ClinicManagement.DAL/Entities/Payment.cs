using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("record_id")]
        public int? RecordId { get; set; }

        [Column("prescription_id")]
        public int? PrescriptionId { get; set; }

        [Column("amount")]
        [Required]
        [Precision(10, 2)]
        public decimal Amount { get; set; }

        [Column("payment_method")]
        [MaxLength(20)]
        public string PaymentMethod { get; set; } // Cash, Card, Transfer, Insurance

        [Column("payment_date")]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Paid"; // Paid, Pending, Refunded

        [Column("transaction_id")]
        [MaxLength(100)]
        public string TransactionId { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("RecordId")]
        public virtual MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual Prescription Prescription { get; set; }
    }
}