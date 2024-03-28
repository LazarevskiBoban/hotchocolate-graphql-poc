using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.Services.Employee;
using HotChocolate.Subscriptions;

namespace HotChocolate.GraphQLAPI.Scheme.Employee
{
    [ExtendObjectType(typeof(BaseMutation))]
    public class EmployeeMutations
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITopicEventSender _sender;

        public EmployeeMutations(IEmployeeService employeeService, ITopicEventSender sender)
        {
            _employeeService = employeeService;
            _sender = sender;
        }

        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = await _employeeService.CreateAsync(employeeDTO);

            await _sender.SendAsync(nameof(EmployeeSubscriptions.EmployeeHasBeenCreated), employee);

            return employee;
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = await _employeeService.UpdateAsync(employeeDTO);

            await _sender.SendAsync($"{nameof(EmployeeSubscriptions.EmployeeHasBeenUpdated)}_{employee.Id}", employee);

            return employee;
        }

        public Task<bool> DeleteEmployee(Guid id)
        {
            return _employeeService.DeleteAsync(id);
        }
    }
}