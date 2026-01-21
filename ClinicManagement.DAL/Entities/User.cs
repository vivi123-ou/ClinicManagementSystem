using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ClinicManagement.DAL.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Column("password_hash")]
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Column("role")]
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // Admin, Doctor, Receptionist

        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("phone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation property
        public virtual Doctor Doctor { get; set; }
    }
}