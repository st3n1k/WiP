using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WiP.Core.Entity;
using WiP.Core.Interfaces.Repositories;
using WiP.Infrastructure.Data.Context;

namespace WiP.Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly WiPContext _writeContext;
        public GenericRepository(WiPContext writeContext)
        {
            _writeContext = writeContext;
        }

        public void Add(T entity)
        {
            _writeContext.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _writeContext.Set<T>().AddRange(entities);
        }

        //public async Task<int> CountAsync(ISpecification<T> spec)
        //{
        //    return await ApplySpecification(spec).CountAsync();
        //}

        public void Delete(T entity)
        {
            _writeContext.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _writeContext.Set<T>().RemoveRange(entities);
        }

        public void DeleteRange(List<T> entities)
        {
            _writeContext.Set<T>().RemoveRange(entities);
        }

        public async Task<List<TProjection>> GetAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection)
        {
            return await _writeContext.Set<T>().Where(filter).Select(projection).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {

            return await _writeContext.Set<T>().FindAsync(id);
        }

        //public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
        //{
        //    return await ApplySpecification(spec).FirstOrDefaultAsync();
        //}

        public async Task<TProjection> GetFirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, Expression<Func<T, object>>? orderBy = null, Expression<Func<T, object>>? orderByDesc = null)
        {
            var query = _writeContext.Set<T>().Where(filter);
            if (orderBy != null) query = query.OrderBy(orderBy);
            if (orderByDesc != null) query = query.OrderByDescending(orderByDesc);
#pragma warning disable CS8603 // Possible null reference return.
            return await query.Select(projection).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IList<T>> ListAllAsync()
        {
            return await _writeContext.Set<T>().ToListAsync();
        }

        //public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        //{
        //    var query = ApplySpecification(spec);

        //    return await query.ToListAsync();
        //}

        public void Update(T entity)
        {
            _writeContext.Set<T>().Attach(entity);
            _writeContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _writeContext.Set<T>().Attach(entity);
                _writeContext.Entry(entity).State = EntityState.Modified;
            }
        }

        //private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        //{
        //    return SpecificationEvaluator<T>.GetQuery(_writeContext.Set<T>().AsQueryable(), spec);
        //}
    }
}
