using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Common.DTOs
{
    // DTO for returning doctor data
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public int ExperienceYears { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // DTO for creating new doctor
    public class CreateDoctorDTO
    {
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Specialty { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        public int ExperienceYears { get; set; } = 0;

        public decimal ConsultationFee { get; set; } = 0;

        public int? UserId { get; set; }
    }

    // DTO for updating doctor
    public class UpdateDoctorDTO
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Specialty { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        public int ExperienceYears { get; set; }

        public decimal ConsultationFee { get; set; }
    }
}