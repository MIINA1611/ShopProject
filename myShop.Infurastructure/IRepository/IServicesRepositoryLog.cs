namespace myShop.Infurastructure
{
    public interface IServicesRepositoryLog<T> where T : class
    {
        List<T> GetAll();
        T GetBy(Guid Id);

        bool Save(Guid Id, Guid UserId);
        bool Update(Guid Id, Guid UserId);

        bool Delete(Guid Id, Guid UserId);
        bool DeleteLog(Guid Id);
    }
}
