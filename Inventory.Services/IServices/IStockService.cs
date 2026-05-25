using Inventory.Models;

namespace Inventory.Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetAllStocks();

        Stock GetStockById(int id);

        void UpdateStock(Stock stock);

        void DeleteStock(int id);
    }
}