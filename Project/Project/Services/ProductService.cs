using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.DTO;
using Project.Entity;
using Project.ViewModels;

namespace Project.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) => _context = context;

        public async Task<List<ProductDTO>> GetAllProductsAsync() =>
            await _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CreatedAt = p.CreatedAt
            }).ToListAsync();

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product == null ? null : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task CreateProductAsync(CreateProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, CreateProductViewModel model)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}