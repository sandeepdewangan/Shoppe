using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using System.ComponentModel.DataAnnotations;

namespace ShoppeWeb.Pages.Customer
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public MenuItem Item { get; set; }
        [Range(1,100, ErrorMessage ="Please select range from 1 to 100")]
        public int Count { get; set; } 

        public async void OnGet(int id)
        {
            Item = _db.MenuItem.Include(c => c.Category).Include(t => t.FoodType).FirstOrDefault();

        }
    }
}
