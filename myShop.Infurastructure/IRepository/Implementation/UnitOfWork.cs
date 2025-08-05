using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.DataAccess.Data;
using myShop.Infurastructure.IRepository.IServicesRepository;

namespace myShop.Infurastructure.IRepository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(ShopDbContext context)
        {
            this._context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }
        public int Complete()
        {
           return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
