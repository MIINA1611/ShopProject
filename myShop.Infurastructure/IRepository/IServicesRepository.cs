using System.Linq.Expressions;

namespace myShop.Infurastructure
{
    public interface IServicesRepository<T> where T : class
    {
        public T GetBy(Expression<Func<T,bool>>? predication = null,string? wordInclude = null);
        public List<T> GetAll(Expression<Func<T, bool>>? predication = null, string? wordInclude = null);
        public void Add(T Entity);
        public void DeleteAlways(T Entites);
        public void DeleteRange(List<T> Entites);
    }
}
