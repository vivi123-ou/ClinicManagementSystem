using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("medical_records")]
    public class MedicalRecord
    {
        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("doctor_id")]
        public int? DoctorId { get; set; }

        [Column("appointment_id")]
        public int? AppointmentId { get; set; }

        [Column("visit_date")]
        [Required]
        public DateTime VisitDate { get; set; }

        [Column("diagnosis")]
        public string Diagnosis { get; set; }

        [Column("symptoms")]
        public string Symptoms { get; set; }

        [Column("treatment")]
        public string Treatment { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("follow_up_date")]
        public DateTime? FollowUpDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}