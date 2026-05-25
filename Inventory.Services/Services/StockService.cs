using Inventory.Models;
using Inventory.UnitOfWork;

namespace Inventory.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _unitOfWork.Stocks.GetAll();
        }

        public Stock GetStockById(int id)
        {
            return _unitOfWork.Stocks.GetById(id);
        }

        public void UpdateStock(Stock stock)
        {
            _unitOfWork.Stocks.Update(stock);

            _unitOfWork.Save();
        }

        public void DeleteStock(int id)
        {
            var stock = _unitOfWork.Stocks.GetById(id);

            if (stock != null)
            {
                _unitOfWork.Stocks.Delete(stock);

                _unitOfWork.Save();
            }
        }
    }
}