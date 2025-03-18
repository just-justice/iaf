using Microsoft.EntityFrameworkCore;
using A9.Entities;

namespace A9.Data
{
    public class A9DbContext : DbContext
    {
        public A9DbContext(DbContextOptions<A9DbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
