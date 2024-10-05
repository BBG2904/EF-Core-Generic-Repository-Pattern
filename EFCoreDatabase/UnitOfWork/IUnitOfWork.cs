using EFCoreDatabase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabase.UnitOfWork
{
    public interface IUnitOfWork<T>: IDisposable
        where T : class
    {
        IGenericRepository<T> EntityRepository { get; }
        Task Complete();
    }
}
