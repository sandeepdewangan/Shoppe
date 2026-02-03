using ShoppeWeb.Models;

namespace Shoppe.DataAccess.Repository
{
    public interface ICategoryRepository
    {
        void Update(Category category);
        void Save();
        void Add(Category category);
    }
}
