using Microsoft.AspNetCore.Mvc;
using ShoppeWeb.DataAccess.Data;
using System.Security.Claims;

namespace ShoppeWeb.ViewComponents
{
    public class ShoppingCartCountViewComponent : ViewComponent
    {
        public readonly ApplicationDbContext _db;

        public ShoppingCartCountViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // get current user
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int count = 0;
            if (claim != null)
            {
                // user is logged in
                // TODO:
                count = 7;
                return View(count);
            }
            else
            {
                // user not logged in
                return View(count);
            }
        }
    }
}
