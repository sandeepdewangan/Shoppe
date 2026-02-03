using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;

namespace ShoppeWeb.Pages.Admin.Categories
{
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
