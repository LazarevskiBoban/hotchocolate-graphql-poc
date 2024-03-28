using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.Services.Employee;
using HotChocolate.Database;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.GraphQLAPI.Scheme.Employee
{
    [ExtendObjectType(typeof(BaseQuery))]
    public class EmployeeQueries
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeQueries(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<EmployeeDTO> GetEmployeeById(Guid id)
        {
            return _employeeService.GetByIdAsync(id);
        }

        [UsePaging]
        public Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return _employeeService.GetAllAsync();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EmployeeDTO> GetEmployeesQuery(
            [Service] IDbContextFactory<Context> dbContextFactory)
        {
            var context = dbContextFactory.CreateDbContext();

            return context.Employees
                .Select(employee => new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    JobTitle = employee.JobTitle,
                });
        }
    }
}