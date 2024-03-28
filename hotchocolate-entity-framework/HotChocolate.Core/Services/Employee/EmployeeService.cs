using AutoMapper;
using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.RepositoryContracts;

namespace HotChocolate.Core.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<EmployeeDTO>> GetManyByCompanyIds(IReadOnlyList<Guid> companyIds)
        {
            var employees = await _employeeRepository.GetManyByCompanyIds(companyIds);

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        /// <inheritdoc />
        public async Task<EmployeeDTO> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            return _mapper.Map<EmployeeDTO>(employee);
        }

        /// <inheritdoc />
        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO employee)
        {
            var newEmployee = _mapper.Map<Models.Entities.Employee>(employee);

            var createdEmployee = await _employeeRepository.AddAsync(newEmployee);

            return _mapper.Map<EmployeeDTO>(createdEmployee);
        }

        /// <inheritdoc />
        public async Task<EmployeeDTO> UpdateAsync(EmployeeDTO employee)
        {
            var employeeToUpdate = _mapper.Map<Models.Entities.Employee>(employee);

            var updatedEmployee = await _employeeRepository.UpdateAsync(employeeToUpdate);

            return _mapper.Map<EmployeeDTO>(updatedEmployee);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(Guid id)
        {
            return _employeeRepository.DeleteAsync(id);
        }
    }
}