using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;

namespace ShoppeWeb.Pages.Customer
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            MenuItemList = _db.MenuItem.Include(i=>i.Category).Include(i=>i.FoodType).ToList();
            CategoryList = _db.Category.OrderBy(o => o.DisplayOrder);
        }
    }
}
