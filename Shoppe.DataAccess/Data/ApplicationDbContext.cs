using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.Models;

namespace ShoppeWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Register the table
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
