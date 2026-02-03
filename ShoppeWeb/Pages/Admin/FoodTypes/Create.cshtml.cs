using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        [BindProperty]
        public FoodType FoodType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
          

            if (ModelState.IsValid)
            {
                await _db.FoodType.AddAsync(FoodType);
                await _db.SaveChangesAsync();
                // TempData for one time message, survives a redirect only.
                TempData["success"] = "FoodType created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
