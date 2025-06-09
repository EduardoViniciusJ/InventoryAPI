using Microsoft.EntityFrameworkCore;
using TestesAPI.Models;

namespace Inventory.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        DbSet<Product> Products { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Stock> Stock { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
