using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Core.RepositoryContracts.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        ///         Get all
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        ///         Get all with childs
        /// </summary>
        Task<IEnumerable<T>> GetAllWithChildIncludesAsync(Func<DbSet<T>, IQueryable<T>> includer);

        /// <summary>
        ///         Get by id
        /// </summary>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        ///         Add entity
        /// </summary>
        Task<T> AddAsync(T entity);

        /// <summary>
        ///         Update entity
        /// </summary>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        ///         Delete entity
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}