using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.RepositoryContracts;
using HotChocolate.Database.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Database.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContextFactory<Context> context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Employee>> GetManyByCompanyIds(IReadOnlyList<Guid> companyIds)
        {
            using Context context = _contextFactory.CreateDbContext();

            return await context
                .Set<Employee>()
                .Where(e => companyIds.Contains((Guid)e.CompanyId))
                .ToListAsync();
        }
    }
}