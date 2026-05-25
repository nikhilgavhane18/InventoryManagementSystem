using Inventory.Models;

namespace Inventory.Repositories.IRepository
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAll();

        Stock GetById(int id);

        void Update(Stock stock);

        void Delete(Stock stock);
    }
}