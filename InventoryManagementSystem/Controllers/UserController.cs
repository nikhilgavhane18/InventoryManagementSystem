using Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IProductService _productService;

        public UserController(IProductService productService)
        {
            _productService = productService;
        }

        // HOME PAGE
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            return View(products);
        }

        // PRODUCT DETAILS
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}