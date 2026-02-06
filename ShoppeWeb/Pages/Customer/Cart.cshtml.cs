using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shoppe.Models;
using ShoppeWeb.DataAccess.Data;
using System.Security.Claims;

namespace ShoppeWeb.Pages.Customer
{
    [Authorize]
    public class CartModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public double CartTotal { get; set; }
        public CartModel(ApplicationDbContext db)
        {
            _db = db;
            CartTotal = 0;
        }
        public void OnGet()
        {
            // Get the user id
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                // get the shopping cart items for the user
                ShoppingCartList = _db.ShoppingCart.Include(m => m.MenuItem).ThenInclude(c => c.Category)
                    .Include(m => m.MenuItem).ThenInclude(f => f.FoodType).Where(c => c.ApplicationUserId == claim.Value).ToList();


                // calculate cart total
                foreach (var cart in ShoppingCartList)
                {
                    CartTotal = CartTotal + (cart.MenuItem.Price * cart.Count);
                }
            }
        }


        public IActionResult OnPostIncrement(int cartId)
        {
            var cart = _db.ShoppingCart.FirstOrDefault(u => u.Id == cartId);
            if (cart == null)
            {
                return NotFound();
            }
            cart.Count = cart.Count + 1;
            _db.ShoppingCart.Update(cart);
            _db.SaveChanges();

            return RedirectToPage("/Customer/Cart");
        }

        public async Task<IActionResult> OnPostRemove(int cartId)
        {
            var item = await _db.ShoppingCart.FindAsync(cartId);

            if (item != null)
            {
                _db.ShoppingCart.Remove(item);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("/Customer/Cart");
        }
    }
}
