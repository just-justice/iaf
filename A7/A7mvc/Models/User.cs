using System.ComponentModel.DataAnnotations;

namespace A7mvc.Models
{
    public class User
    {
        [Required]
        public string? Username { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        [Required, Range(1, 120, ErrorMessage = "Age must be positive")]
        public int Age { get; set; }

        [Required, Phone]
        public string? PhoneNumber { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Donation must be greater than zero.")]
        public decimal Donation { get; set; }
    }
}
