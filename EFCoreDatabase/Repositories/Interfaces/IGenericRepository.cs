namespace EFCoreDatabase.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
        Task<T> GetById(int id);
    }
}
