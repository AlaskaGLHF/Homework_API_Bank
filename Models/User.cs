using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string? Patronymic { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string HashPassword { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "active";

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; } = null; 
    }
}
