using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        public int AppointmentId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("doctor_id")]
        public int? DoctorId { get; set; }

        [Column("appointment_date")]
        [Required]
        public DateTime AppointmentDate { get; set; }

        [Column("appointment_time")]
        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled, No-show

        [Column("reason")]
        public string Reason { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}