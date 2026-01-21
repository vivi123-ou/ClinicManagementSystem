using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.DAL.Entities
{
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Column("date_of_birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("gender")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Column("phone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("identity_card")]
        [MaxLength(20)]
        public string IdentityCard { get; set; }

        [Column("blood_type")]
        [MaxLength(5)]
        public string BloodType { get; set; }

        [Column("allergies")]
        public string Allergies { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}