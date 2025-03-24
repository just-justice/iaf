using A10.Dto;
using A10.Entity;
using A10.Repository;

namespace A10.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productRepository.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _productRepository.GetByIdAsync(id);

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, Price = productDto.Price };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                await _productRepository.UpdateAsync(product);
            }
        }

        public async Task DeleteProductAsync(int id) => await _productRepository.DeleteAsync(id);
    }
}
