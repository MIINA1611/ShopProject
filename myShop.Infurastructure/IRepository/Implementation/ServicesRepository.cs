using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myShop.DataAccess.Data;

namespace myShop.Infurastructure.IRepository.Implementation
{
    public class ServicesRepository<T> : IServicesRepository<T> where T : class
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<T> _dbSet;
        public ServicesRepository(ShopDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T Entity)
        {
            _dbSet.Add(Entity);
        }

        public void DeleteAlways(T Entites)
        {
            _dbSet.Remove(Entites);
        }

        public void DeleteRange(List<T> Entites)
        {
            _dbSet.RemoveRange(Entites);
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? predication=null, string? wordInclude = null)
        {
            IQueryable<T> query = _dbSet;
            if (predication !=null)
            {
                query = query.Where(predication);
            }
            if(wordInclude != null)
            {
                foreach (var include in wordInclude.Split(new char[]  { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public T GetBy(System.Linq.Expressions.Expression<Func<T, bool>>? predication= null, string? wordInclude = null)
        {
            IQueryable<T> query = _dbSet;
            if (predication != null)
            {
                query = query.Where(predication);
            }
            if (wordInclude != null)
            {
                foreach (var include in wordInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }
            return query.SingleOrDefault();
        }
    }
}
