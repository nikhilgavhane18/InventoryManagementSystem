using Inventory.Models;
using Inventory.UnitOfWork;

namespace Inventory.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Categories.Get(id);
        }

        public void CreateCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Save();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
                _unitOfWork.Save();
            }
        }
    }
}