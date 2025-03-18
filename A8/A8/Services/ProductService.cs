using A8.Interface;
using A8.ViewModels;
using A8.Data;
using A8.Entity;
using System.Collections.Generic;
using System.Linq;

namespace A8.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all products
        public List<ProductViewModel> GetAllProducts()
        {
            return _context.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Description = p.Description,
                QuantityRemaining = p.QuantityRemaining
            }).ToList();
        }

        // Search products by name
        public List<ProductViewModel> SearchProducts(string searchTerm)
        {
            return _context.Products
                .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()))
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    Description = p.Description,
                    QuantityRemaining = p.QuantityRemaining
                }).ToList();
        }

        // Retrieve a product by ID
        public ProductViewModel GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return null;

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                QuantityRemaining = product.QuantityRemaining
            };
        }

        // Add a new product
        public void AddProduct(ProductViewModel model)
        {
            // Ensure the ID is being treated as an integer
            if (_context.Products.Any(p => p.Id == model.Id))
            {
                throw new System.Exception("Product ID must be unique.");
            }

            var product = new Product
            {
                Id = model.Id,  // Ensure ID is an integer
                Name = model.Name,
                Category = model.Category,
                Description = model.Description,
                QuantityRemaining = model.QuantityRemaining
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Update an existing product
        public void UpdateProduct(ProductViewModel model)
        {
            var product = _context.Products.Find(model.Id);
            if (product == null)
                throw new System.Exception("Product not found.");

            product.Name = model.Name;
            product.Category = model.Category;
            product.Description = model.Description;
            product.QuantityRemaining = model.QuantityRemaining;

            _context.SaveChanges();
        }

        // Delete a product
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
