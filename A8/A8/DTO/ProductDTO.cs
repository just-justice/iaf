using System.ComponentModel.DataAnnotations;

namespace A8.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; } // Unique Product ID

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int QuantityRemaining { get; set; }
    }
}
