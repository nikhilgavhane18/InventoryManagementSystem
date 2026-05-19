using Inventory.DataAccess;
using Inventory.Repositories;
using Inventory.Repositories.IRepository;

namespace Inventory.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Products = new ProductRepository(_context);

            Categories = new CategoryRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}