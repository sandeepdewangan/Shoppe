using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;

namespace ShoppeWeb.Pages.Admin.MenuItems
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            MenuItems = _db.MenuItem;
        }
    }
}
