using EFCoreDatabase.Context;
using EFCoreDatabase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabase.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : class
    {
        private readonly OrderDBContext _dbContext;
        private readonly IGenericRepository<T> _genericRepository;

        public UnitOfWork(OrderDBContext dbContext, IGenericRepository<T> repository)
        {
            _dbContext = dbContext;
            _genericRepository = repository;
        }

        public IGenericRepository<T> EntityRepository {
           get{ return _genericRepository;}
        }

        public async Task Complete()
        {
           await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();  
        }
    }
}
