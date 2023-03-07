using Microsoft.EntityFrameworkCore;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Domain.Common;
using SamsungShops.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace SamsungShops.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly SamsungShopsContext _samsungShopsContext;
        protected DbSet<T> DbSet => _samsungShopsContext.Set<T>();

        public RepositoryBase(SamsungShopsContext samsungShopsContext)
        {
            _samsungShopsContext = samsungShopsContext ?? throw new ArgumentNullException(nameof(samsungShopsContext));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }


        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true, int skipRowsCount = 0, int takeRowsCount = 10)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            query = query.Skip(skipRowsCount).Take(takeRowsCount);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await _samsungShopsContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _samsungShopsContext.Entry(entity).State = EntityState.Modified;
            await _samsungShopsContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _samsungShopsContext.SaveChangesAsync();
        }
    }
}
