using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.RepositoryContracts.Generic;

namespace HotChocolate.Core.RepositoryContracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        /// <summary>
        ///         Get employees for provided company.
        /// </summary>
        Task<IEnumerable<Employee>> GetManyByCompanyIds(IReadOnlyList<Guid> companyIds);
    }
}