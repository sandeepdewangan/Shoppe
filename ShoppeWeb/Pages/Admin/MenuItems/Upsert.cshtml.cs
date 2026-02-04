using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Shoppe.DataAccess.Repository;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;


namespace ShoppeWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        // For uploading image
        public readonly IWebHostEnvironment _hostEnvirnment;

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _hostEnvirnment = env;
            MenuItem = new();
        }
        public void OnGet()
        {
            CategoryList = _db.Category.Select(i=> new SelectListItem(){
                Text = i.Name,
                Value = i.id.ToString(),
            });

            FoodTypeList = _db.FoodType.Select(i => new SelectListItem()
            {
                Text = i.Type,
                Value = i.id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvirnment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (MenuItem.Id == 0)
            {
                // Insert
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menu_items");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName+extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\images\menu_items\" + fileName + extension;
                // Add to database
                _db.MenuItem.Add(MenuItem);
                await _db.SaveChangesAsync();
            }else{
                // Edit
            }

            return RedirectToPage("Index");
        }
    }
}
