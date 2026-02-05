using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using System.ComponentModel.DataAnnotations;


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
            ShoppingCart = new()
            {
                MenuItem = _db.MenuItem.Include(c => c.Category).Include(t => t.FoodType).FirstOrDefault(u => u.Id == id),
            };
        }
    }
}
