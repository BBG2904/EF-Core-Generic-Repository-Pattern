using EFCoreDatabase.Context;
using EFCoreDatabase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabase.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private OrderDBContext _context = null;
        
        public GenericRepository(OrderDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }



        public async  Task Update(T obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Delete(int id)
        {
            T obj = await GetById(id);
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
        }

    }
}
