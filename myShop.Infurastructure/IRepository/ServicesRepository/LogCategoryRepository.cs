using Microsoft.EntityFrameworkCore;
using myShop.DataAccess.Data;
using myShop.Entites.Models;

namespace myShop.Infurastructure.IRepository.ServicesRepository
{
    public class LogCategoryRepository : IServicesRepositoryLog<LogCategory>
    {
        private readonly ShopDbContext _context;

        public LogCategoryRepository(ShopDbContext context)
        {
            this._context = context;
        }
        public bool Delete(Guid Id, Guid UserId)
        {
            try
            {
                var model= new LogCategory
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId,
                    Action = Helper.Delete,
                    Date = DateTime.Now,
                    CategoryId=Id,
                };
                _context.LogCategories.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLog(Guid Id)
        {
            try
            {
                var result= GetBy(Id);
                if(result != null)
                {           
                    _context.LogCategories.Remove(result);
                    _context.SaveChanges();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<LogCategory> GetAll()
        {
            try
            {
                return _context.LogCategories.Include(x=>x.Category).OrderBy(x=>x.Date).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public LogCategory GetBy(Guid Id)
        {
            try
            {
                return _context.LogCategories.Include(x => x.Category).OrderBy(x => x.Date).FirstOrDefault(x=>x.Id==x.Id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Save(Guid Id, Guid UserId)
        {
            try
            {
                var model = new LogCategory
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId,
                    Action = Helper.Save,
                    Date = DateTime.Now,
                    CategoryId = Id,
                };
                _context.LogCategories.Add(model);
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Guid Id, Guid UserId)
        {
            try
            {
                var result = GetBy(Id);
                var model = new LogCategory
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId,
                    Action = Helper.Update,
                    Date = DateTime.Now,
                    CategoryId = Id,
                };
                _context.LogCategories.Add(model);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
