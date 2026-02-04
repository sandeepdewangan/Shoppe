using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnPostDelete(int id)
        {
            // delete logic
            var fromDb = await _db.MenuItem.FindAsync(id);

            if (fromDb == null)
            {
                return NotFound();
            }

            _db.MenuItem.Remove(fromDb);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
