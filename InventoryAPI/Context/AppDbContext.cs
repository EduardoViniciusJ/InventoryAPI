using Microsoft.EntityFrameworkCore;
using TestesAPI.Models;

namespace Inventory.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
