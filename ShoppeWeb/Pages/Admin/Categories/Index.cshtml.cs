using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shoppe.Utils;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;

namespace ShoppeWeb.Pages.Admin.Categories
{
    [Authorize(Roles = $"{SD.ManagerRole}, {SD.KitchenRole}")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            // Retrive all categories from the database
            Categories = _db.Category;
        }
    }
}
