using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace ShoppeWeb.Pages.Customer
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }


        public async void OnGet(int id)
        {
            // Get the user id
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCart = new()
            {
                // asign
                ApplicationUserId = claim.Value,
                MenuItem = _db.MenuItem.Include(c => c.Category).Include(t => t.FoodType).FirstOrDefault(u => u.Id == id),
                MenuItemId = id,
            };
        }

    
        public async Task<IActionResult> OnPost()
        {
            // add to db
            _db.ShoppingCart.Add(ShoppingCart);
            _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
