using HotChocolate.Core.DataLoaders.Company;
using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.Services.Employee;

namespace HotChocolate.Core.Models.GraphQL
{
    /// <summary>
    ///         Ussualy DTO will be different from entity - but for now who cares, let's inherit :)
    /// </summary>
    public class CompanyDTO : Company
    {
        public new async Task<IEnumerable<EmployeeDTO>> Employees(
            //[Service] IEmployeeService employeeService
            [Service] EmployeesDataLoader employeesDataLoader
            )
        {
            var companyIds = new List<Guid> { (Guid)Id };
            //var employees = await employeeService.GetManyByCompanyIds(companyIds);
            var employees = await employeesDataLoader.LoadAsync(companyIds);

            return employees;
        }
    }
}