using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using Shoppe.Utils;
using ShoppeWeb.DataAccess.Data;

namespace Shoppe.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                _db.Database.EnsureCreated();
                // Check if there is pending migrations
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            // Create role if not present in db
            if (!_roleManager.RoleExistsAsync(SD.KitchenRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.KitchenRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

                // create admin
                _userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        UserName = "sandeep@gmail.com",
                        Email = "sandeep@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "Sandeep",
                        LastName = "Dewangan"

                    }, "Sandeep123@").GetAwaiter().GetResult();
                // assign admin role
                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "sandeep@gmail.com");
                _userManager.AddToRoleAsync(user, SD.ManagerRole).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
