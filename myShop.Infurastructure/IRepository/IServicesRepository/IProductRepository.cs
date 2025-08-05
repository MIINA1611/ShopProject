using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.Entites.Models;

namespace myShop.Infurastructure.IRepository.IServicesRepository
{
    public interface IProductRepository : IServicesRepository<Products>
    {
        public void Update(Products product);
        public void Delete(Guid Id);
    }
}
