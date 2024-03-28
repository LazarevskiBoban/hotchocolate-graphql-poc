using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.Services.Company;

namespace HotChocolate.GraphQLAPI.Scheme.Company
{
    [ExtendObjectType(typeof(BaseQuery))]
    public class CompanyQueries
    {
        private readonly ICompanyService _companyService;

        public CompanyQueries(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Task<CompanyDTO> GetCompanyById(Guid id)
        {
            return _companyService.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompanies()
        {
            var companies = await _companyService.GetAllAsync();

            return companies;
        }
    }
}