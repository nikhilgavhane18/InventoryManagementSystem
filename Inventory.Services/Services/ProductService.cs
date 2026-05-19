using Inventory.Models;
using Inventory.UnitOfWork;

namespace Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            if (product != null)
            {
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Save();
            }
        }
    }
}