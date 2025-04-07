using System.Collections.Generic;
using MyProject.Dtos; 

namespace MyProject.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto>? Products { get; set; }
    }
}
