using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using WiP.Core.Entity;
using WiP.Core.Interfaces;
using WiP.Core.Interfaces.Repositories;
using WiP.Infrastructure.Data.Context;
using WiP.Infrastructure.Data.Repository;

namespace WiP.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WiPContext _writeContext;
        private Hashtable? _repositories;
        public UnitOfWork(WiPContext writeContext)
        {
            _writeContext = writeContext;
        }

        public async Task<int> Complete()
        {
            return await _writeContext.SaveChangesAsync();

        }

        public void Dispose()
        {

            _writeContext.Dispose();
        }

        public IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _writeContext);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _writeContext.Database.BeginTransactionAsync();
        }
    }
}
