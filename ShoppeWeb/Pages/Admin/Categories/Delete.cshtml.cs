using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {

            var catFromDb = _db.Category.Find(Category.id);
            if (catFromDb != null)
            {
                _db.Category.Remove(catFromDb);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
