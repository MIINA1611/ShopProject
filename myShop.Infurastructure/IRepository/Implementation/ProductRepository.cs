using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.DataAccess.Data;
using myShop.Entites.Models;
using myShop.Infurastructure.IRepository.IServicesRepository;

namespace myShop.Infurastructure.IRepository.Implementation
{
    public class ProductRepository : ServicesRepository<Products>, IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context) : base(context)
        {
            this._context = context;
        }

        public void Delete(Guid Id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == Id);
            category.CurrentStatue = (int)Helper.eCurrentStatue.Deleted;
            _context.Categories.Update(category);
        }

        public void Update(Products product)
        {
            var result = _context.Products.FirstOrDefault(c => c.Id == product.Id);
            if (result != null)
            {
                result.Id = product.Id;
                result.Name = product.Name;
                result.Description = product.Description;
                result.CurrentStatue = product.CurrentStatue;
                _context.Products.Update(result);
            }
        }
    }
}
