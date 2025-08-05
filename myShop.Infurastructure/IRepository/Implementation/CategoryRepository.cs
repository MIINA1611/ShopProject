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
    public class CategoryRepository : ServicesRepository<Category>, ICategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context) : base(context)
        {
            this._context = context;
        }

        public void Update(Category category)
        {
            var result = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (result != null)
            {
                result.Id = category.Id;
                result.Name = category.Name;
                result.Description = category.Description;
                result.CurrentStatue = category.CurrentStatue;
                _context.Categories.Update(result);
            }
        }

        public void Delete(Guid Id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==Id);
            category.CurrentStatue = (int)Helper.eCurrentStatue.Deleted;
            _context.Categories.Update(category);
        }
    }
}
