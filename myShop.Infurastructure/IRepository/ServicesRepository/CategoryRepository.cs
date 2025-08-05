using myShop.DataAccess.Data;
using myShop.Entites.Models;

namespace myShop.Infurastructure.IRepository.ServicesRepository
{
    //public class CategoryRepository : IServicesRepository<Category>
    //{
    //    private readonly ShopDbContext _context;

    //    public CategoryRepository(ShopDbContext context)
    //    {
    //        this._context = context;
    //    }
    //    public bool Delete(Guid Id)
    //    {
    //        try
    //        {
    //        var categoryDel= _context.Categories.FirstOrDefault(c => c.Id == Id);

    //            categoryDel.CurrentStatue = (int)Helper.eCurrentStatue.Deleted;
    //            _context.Categories.Update(categoryDel);
    //            _context.SaveChanges();
    //            return true;
    //        }catch(Exception)
    //        {
    //            return false;
    //        }
    //    }

    //    public List<Category> GetAll()
    //    {
    //        try
    //        {
    //        return _context.Categories.OrderBy(c => c.Name)
    //            .Where(c => c.CurrentStatue>0)
    //            .ToList();
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }

    //    public Category GetBy(Guid Id)
    //    {
    //        try
    //        {
    //            return _context.Categories
    //                .FirstOrDefault(x => x.Id == Id && x.CurrentStatue > 0);
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }

    //    public Category GetBy(string Name)
    //    {
    //        try
    //        {
    //            return _context.Categories
    //                .FirstOrDefault(x => x.Name == Name && x.CurrentStatue > 0);
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Save(Category Entity)
    //    {
    //        try
    //        {
    //            var result = GetBy(Entity.Id);
    //            if (result == null)
    //            {
    //                Entity.CurrentStatue = (int)Helper.eCurrentStatue.Active;
    //                _context.Categories.Add(Entity);
    //            }
    //            else
    //            {
    //                result.Name = Entity.Name;
    //                result.Description = Entity.Description;
    //                _context.Categories.Update(result);
    //            }
    //            _context.SaveChanges();
    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }
    //    }
   // }
}
