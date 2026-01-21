using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Common.DTOs
{
    // DTO for returning patient data
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdentityCard { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // DTO for creating new patient
    public class CreatePatientDTO
    {
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public string Address { get; set; }

        [StringLength(20)]
        public string IdentityCard { get; set; }

        [StringLength(5)]
        public string BloodType { get; set; }

        public string Allergies { get; set; }
    }

    // DTO for updating patient
    public class UpdatePatientDTO
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public string Address { get; set; }

        [StringLength(20)]
        public string IdentityCard { get; set; }

        [StringLength(5)]
        public string BloodType { get; set; }

        public string Allergies { get; set; }
    }
}