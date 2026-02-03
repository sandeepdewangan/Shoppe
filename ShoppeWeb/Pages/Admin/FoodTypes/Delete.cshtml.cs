using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public FoodType FoodType { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {

            var fTFromDb = _db.FoodType.Find(FoodType.id);
            if (fTFromDb != null)
            {
                _db.FoodType.Remove(fTFromDb);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
