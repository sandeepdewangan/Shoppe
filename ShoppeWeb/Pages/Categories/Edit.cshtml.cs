using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.Data;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            // Custom error
            if(Category.DisplayOrder == 1)
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot be 1.");
            }

            if(ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
