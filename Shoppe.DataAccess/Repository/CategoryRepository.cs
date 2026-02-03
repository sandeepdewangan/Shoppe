using Shoppe.DataAccess.Repository;
using ShoppeWeb.DataAccess.Data;
using ShoppeWeb.Models;

namespace Shoppe.DataAccess.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Category category)
        {
            _db.Category.Add(category);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(u => u.id == category.id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
