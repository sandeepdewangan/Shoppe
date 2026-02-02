using Microsoft.EntityFrameworkCore;
using ShoppeWeb.Models;

namespace ShoppeWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Register the table
        public DbSet<Category> Category { get; set; }
    }
}
