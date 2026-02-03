using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shoppe.DataAccess.Repository;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ICategoryRepository _catDb;

        public CreateModel(ICategoryRepository catDb)
        {
            _catDb = catDb;

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
                _catDb.Add(Category);
                _catDb.Save();
                // TempData for one time message, survives a redirect only.
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
