using AutoMapper;
using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Core.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CompanyDTO> GetByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);

            return _mapper.Map<CompanyDTO>(company);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            //var companies = await _companyRepository.GetAllWithChildIncludesAsync(
            //    (query) => query
            //        .Include(company => company.Employees));

            var companies = await _companyRepository.GetAllAsync();


            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }

        /// <inheritdoc />
        public async Task<CompanyDTO> CreateAsync(CompanyDTO companyDTO)
        {
            var newCompany = _mapper.Map<Models.Entities.Company>(companyDTO);

            var insertedCompany = await _companyRepository.AddAsync(newCompany);

            return _mapper.Map<CompanyDTO>(insertedCompany);
        }

        /// <inheritdoc />
        public async Task<CompanyDTO> UpdateAsync(CompanyDTO companyDTO)
        {
            var companyToUpdate = _mapper.Map<Models.Entities.Company>(companyDTO);

            var updatedCompany = await _companyRepository.UpdateAsync(companyToUpdate);

            return _mapper.Map<CompanyDTO>(updatedCompany);
        }

        /// <inheritdoc />
        public Task<bool> DeleteAsync(Guid id)
        {
            return _companyRepository.DeleteAsync(id);
        }
    }
}