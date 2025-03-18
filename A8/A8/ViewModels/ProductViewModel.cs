using System;

namespace A8.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int QuantityRemaining { get; set; }

        // Constructor to ensure no null value warnings
        public ProductViewModel()
        {
            Name = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
        }
    }
}
