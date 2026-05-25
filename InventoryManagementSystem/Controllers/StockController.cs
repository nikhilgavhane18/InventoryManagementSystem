using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // READ
        public IActionResult Index()
        {
            var stocks = _stockService.GetAllStocks();

            return View(stocks);
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stock = _stockService.GetStockById(id);

            if (stock == null)
                return NotFound();

            return View(stock);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Stock stock)
        {
            if (ModelState.IsValid)
            {
                if (stock.StockQuantity == 0)
                {
                    stock.Status = "Out Of Stock";
                }
                else if (stock.StockQuantity <= 5)
                {
                    stock.Status = "Low Stock";
                }
                else
                {
                    stock.Status = "Available In Stock";
                }

                _stockService.UpdateStock(stock);

                return RedirectToAction("Index");
            }

            return View(stock);
        }

        // DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var stock = _stockService.GetStockById(id);

            if (stock == null)
                return NotFound();

            return View(stock);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult DeleteConfirmed(int StockId)
        {
            _stockService.DeleteStock(StockId);

            return RedirectToAction("Index");
        }
    }
}