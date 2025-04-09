using Project.DTO;
using Project.ViewModels;

namespace Project.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductViewModel model);
        Task UpdateProductAsync(int id, CreateProductViewModel model);
        Task DeleteProductAsync(int id);
    }
}