using Inventory.DataAccess;
using Inventory.Models;
using Inventory.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Stock> GetAll()
        {
            return _context.Stocks
                           .Include(s => s.Product)
                           .ToList();
        }

        public Stock GetById(int id)
        {
            return _context.Stocks
                           .Include(s => s.Product)
                           .FirstOrDefault(s => s.StockId == id);
        }

        public void Update(Stock stock)
        {
            _context.Stocks.Update(stock);
        }

        public void Delete(Stock stock)
        {
            _context.Stocks.Remove(stock);
        }
    }
}