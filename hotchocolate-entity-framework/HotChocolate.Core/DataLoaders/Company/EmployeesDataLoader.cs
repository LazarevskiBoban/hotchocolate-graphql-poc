using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.Services.Employee;

namespace HotChocolate.Core.DataLoaders.Company
{
    public class EmployeesDataLoader : BatchDataLoader<Guid, EmployeeDTO>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesDataLoader(
            IEmployeeService employeeService,
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
            _employeeService = employeeService;
        }

        protected override async Task<IReadOnlyDictionary<Guid, EmployeeDTO>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetManyByCompanyIds(keys);

            return employees.ToDictionary(e => (Guid)e.CompanyId);
        }
    }
}