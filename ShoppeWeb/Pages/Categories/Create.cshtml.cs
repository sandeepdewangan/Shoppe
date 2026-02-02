using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.Data;
using ShoppeWeb.Models;

namespace ShoppeWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // Custom error
            if (Category.DisplayOrder == 1)
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot be 1.");
            }

            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                // TempData for one time message, survives a redirect only.
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
