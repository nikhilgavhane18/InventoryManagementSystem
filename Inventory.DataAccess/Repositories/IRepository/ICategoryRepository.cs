using Inventory.Models;

namespace Inventory.Repositories.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category Get(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}