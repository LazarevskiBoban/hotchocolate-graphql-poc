using HotChocolate.Core.Models.GraphQL;

namespace HotChocolate.Core.Services.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        ///         Get employee by id.
        /// </summary>
        Task<EmployeeDTO> GetByIdAsync(Guid id);

        /// <summary>
        ///         Get all employees.
        /// </summary>
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();

        /// <summary>
        ///         Get all employees by company id.
        /// </summary>
        Task<IEnumerable<EmployeeDTO>> GetManyByCompanyIds(IReadOnlyList<Guid> companyIds);

        /// <summary>
        ///         Create employee.
        /// </summary>
        Task<EmployeeDTO> CreateAsync(EmployeeDTO employeeDTO);

        /// <summary>
        ///         Update employee.
        /// </summary>
        Task<EmployeeDTO> UpdateAsync(EmployeeDTO employeeDTO);

        /// <summary>
        ///         Delete employee.
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}