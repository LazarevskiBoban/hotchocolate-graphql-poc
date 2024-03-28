using HotChocolate.Core.Models.GraphQL;
using HotChocolate.Core.Services.Company;
using HotChocolate.Subscriptions;

namespace HotChocolate.GraphQLAPI.Scheme.Company
{
    [ExtendObjectType(typeof(BaseMutation))]
    public class CompanyMutations
    {
        private readonly ICompanyService _companyService;
        private readonly ITopicEventSender _sender;

        public CompanyMutations(ICompanyService companyService, ITopicEventSender sender)
        {
            _companyService = companyService;
            _sender = sender;
        }

        public async Task<CompanyDTO> CreateCompany(CompanyDTO companyDTO)
        {
            var company = await _companyService.CreateAsync(companyDTO);

            await _sender.SendAsync(nameof(CompanySubscriptions.CompanyHasBeenCreated), company);

            return company;
        }

        public async Task<CompanyDTO> UpdateCompany(CompanyDTO companyDTO)
        {
            var company = await _companyService.UpdateAsync(companyDTO);

            await _sender.SendAsync($"{nameof(CompanySubscriptions.CompanyHasBeenUpdated)}_{company.Id}", company);

            return company;
        }

        public Task<bool> DeleteCompany(Guid id)
        {
            return _companyService.DeleteAsync(id);
        }
    }
}