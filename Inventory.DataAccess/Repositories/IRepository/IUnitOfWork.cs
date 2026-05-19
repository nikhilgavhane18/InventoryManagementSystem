using Inventory.Repositories;
using Inventory.Repositories.IRepository;

namespace Inventory.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        void Save();
    }
}