using MyProject.Models;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductWithDetailsAsync(int id);
    }
}
