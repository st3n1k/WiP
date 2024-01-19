using WiP.Core.Entity;
using WiP.Core.Interfaces.Repositories;

namespace WiP.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }

}
