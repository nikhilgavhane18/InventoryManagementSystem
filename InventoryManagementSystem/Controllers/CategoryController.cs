using Inventory.Models;
using Inventory.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // READ
        public IActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetAll();

            return View(categories);
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Add(category);

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Update(category);

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            var data = _unitOfWork.Categories.Get(category.CId);

            if (data == null)
            {
                return NotFound();
            }

            _unitOfWork.Categories.Delete(data);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}