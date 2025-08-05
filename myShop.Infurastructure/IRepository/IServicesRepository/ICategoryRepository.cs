using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.Entites.Models;

namespace myShop.Infurastructure.IRepository.IServicesRepository
{
    public interface ICategoryRepository : IServicesRepository<Category>
    {
        public void Update(Category category);
        public void Delete(Guid Id);
    }
}
