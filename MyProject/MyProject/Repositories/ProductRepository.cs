using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Product> GetProductWithDetailsAsync(int id)
        {
            return await _context.Products
                                 .FirstOrDefaultAsync(p => p.ProductID == id);
        }
    }
}
