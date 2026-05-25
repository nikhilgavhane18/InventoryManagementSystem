using Inventory.DataAccess;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Supplier")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public ProductsController(
            IProductService productService,
            ICategoryService categoryService,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            return View(products);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product,
                                    IFormFile ImageFile,
                                    int StockQuantity)
        {
            if (ModelState.IsValid)
            {
                // IMAGE UPLOAD
                if (ImageFile != null)
                {
                    string folder = Path.Combine(
                        _webHostEnvironment.WebRootPath,
                        "images"
                    );

                    string fileName = Guid.NewGuid().ToString()
                                      + "_" + ImageFile.FileName;

                    string filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    product.ImagePath = "/images/" + fileName;
                }

                // SAVE PRODUCT
                _productService.CreateProduct(product);

                // STOCK STATUS
                string status;

                if (StockQuantity == 0)
                {
                    status = "Out Of Stock";
                }
                else if (StockQuantity <= 5)
                {
                    status = "Low Stock";
                }
                else
                {
                    status = "Available In Stock";
                }

                // CREATE STOCK ENTRY
                Stock stock = new Stock()
                {
                    PId = product.PId,
                    StockQuantity = StockQuantity,
                    Status = status
                };

                _context.Stocks.Add(stock);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAllCategories();

            return View(product);
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            ViewBag.CategoryList = new SelectList(
                _categoryService.GetAllCategories(),
                "CId",
                "CategoryName"
            );

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product,
                                  IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                // FETCH OLD PRODUCT
                var existingProduct =
                    _productService.GetProductById(product.PId);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                // NEW IMAGE
                if (ImageFile != null)
                {
                    string folder = Path.Combine(
                        _webHostEnvironment.WebRootPath,
                        "images"
                    );

                    string fileName = Guid.NewGuid().ToString()
                                      + "_" + ImageFile.FileName;

                    string filePath = Path.Combine(folder, fileName);

                    using (var stream =
                           new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    product.ImagePath = "/images/" + fileName;
                }
                else
                {
                    // KEEP OLD IMAGE
                    product.ImagePath =
                        existingProduct.ImagePath;
                }

                _productService.UpdateProduct(product);

                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = new SelectList(
                _categoryService.GetAllCategories(),
                "CId",
                "CategoryName"
            );

            return View(product);
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int PId)
        {
            _productService.DeleteProduct(PId);

            return RedirectToAction("Index");
        }

        // DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // MANAGE STOCK
        [HttpGet]
        public IActionResult ManageStock()
        {
            var products = _productService.GetAllProducts();

            return View(products);
        }
    }
}