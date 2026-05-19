using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;

namespace InventoryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
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
        public IActionResult Create(Product product, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // IMAGE UPLOAD
                if (ImageFile != null)
                {
                    string folder =
                        Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    string fileName = Guid.NewGuid().ToString()
                                      + "_"
                                      + ImageFile.FileName;

                    string filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    // SAVE PATH IN DATABASE
                    product.ImagePath = "/images/" + fileName;
                }

                _productService.CreateProduct(product);

                return RedirectToAction("Index");
            }

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
             "CId", "CategoryName"
              );

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string folder =
                        Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    string fileName =
                        Guid.NewGuid().ToString()
                        + "_"
                        + ImageFile.FileName;

                    string filePath =
                        Path.Combine(folder, fileName);

                    using (var stream =
                           new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    product.ImagePath = "/images/" + fileName;
                }

                _productService.UpdateProduct(product);

                return RedirectToAction("Index");
            }

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
    }
}