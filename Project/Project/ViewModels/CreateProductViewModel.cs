using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
