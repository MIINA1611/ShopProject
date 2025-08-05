using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.Infurastructure.IRepository.IServicesRepository;

namespace myShop.Infurastructure.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category{ get; }
        IProductRepository Product{ get; }
        int Complete();
    }
}
