using Microsoft.EntityFrameworkCore;
using A8.Entity;

namespace A8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } 
    }
}
