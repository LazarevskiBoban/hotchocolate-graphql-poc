using HotChocolate.Core.Models.Entities.Generic;
using HotChocolate.Core.RepositoryContracts.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Database.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        internal readonly IDbContextFactory<Context> _contextFactory;

        public GenericRepository(IDbContextFactory<Context> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using Context context = _contextFactory.CreateDbContext();

            return await context.Set<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllWithChildIncludesAsync(
            Func<DbSet<T>, IQueryable<T>> includeChildsBuilder)
        {
            using Context context = _contextFactory.CreateDbContext();

            var entityQuerySet = context.Set<T>();

            var includedChildsQuery = includeChildsBuilder(entityQuerySet);

            return await includedChildsQuery.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync(Guid id)
        {
            using Context context = _contextFactory.CreateDbContext();

            return await context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T entity)
        {
            using Context context = _contextFactory.CreateDbContext();

            var result = await context.Set<T>().AddAsync(entity);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        /// <inheritdoc />
        public async Task<T> UpdateAsync(T entity)
        {
            using Context context = _contextFactory.CreateDbContext();

            var entityToEdit = await context
                .Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == entity.Id)
                ?? throw new ArgumentNullException("Entity with that Id does not exist");

            var updated = context.Update(entity);

            await context.SaveChangesAsync();

            return updated.Entity;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id)
        {
            using Context context = _contextFactory.CreateDbContext();

            var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id)
                 ?? throw new ArgumentNullException("Entity with that Id does not exist"); ;

            context.Set<T>().Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}