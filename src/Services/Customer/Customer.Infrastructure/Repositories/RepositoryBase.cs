using Customer.Application.Contracts.Persistence;
using Customer.Domain.Common;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Repositories
{
    public class RepositoryBase<T>(CustomerContext dbContext) : IRepositoryBase<T>
        where T : EntityBase
        {
        protected readonly CustomerContext DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        // public async Task<IReadOnlyList<T>> GetAllAsync()
        // {
        //     return await DbContext.Set<T>().ToListAsync();
        // }
        //
        // public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        // {
        //     return await DbContext.Set<T>().Where(predicate).ToListAsync();
        // }
        //
        // public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTracking = true)
        // {
        //     IQueryable<T> query = DbContext.Set<T>();
        //     if (disableTracking) query = query.AsNoTracking();
        //
        //     if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
        //
        //     if (predicate != null) query = query.Where(predicate);
        //
        //     if (orderBy != null)
        //         return await orderBy(query).ToListAsync();
        //     return await query.ToListAsync();
        // }
        //
        // public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
        // {
        //     IQueryable<T> query = DbContext.Set<T>();
        //     if (disableTracking) query = query.AsNoTracking();
        //
        //     if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
        //
        //     if (predicate != null) query = query.Where(predicate);
        //
        //     if (orderBy != null)
        //         return await orderBy(query).ToListAsync();
        //     return await query.ToListAsync();
        // }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
