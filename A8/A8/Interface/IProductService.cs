using A8.ViewModels;
using System.Collections.Generic;

namespace A8.Interface
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> SearchProducts(string searchTerm);
        ProductViewModel GetProductById(int id);
        void AddProduct(ProductViewModel product);
        void UpdateProduct(ProductViewModel product);
        void DeleteProduct(int id);
    }
}
