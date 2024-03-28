using HotChocolate.Core.Models.GraphQL;

namespace HotChocolate.Core.Services.Company
{
    public interface ICompanyService
    {
        /// <summary>
        ///         Get company by id.
        /// </summary>
        Task<CompanyDTO> GetByIdAsync(Guid id);

        /// <summary>
        ///         Get all companies.
        /// </summary>
        Task<IEnumerable<CompanyDTO>> GetAllAsync();

        /// <summary>
        ///         Create company.
        /// </summary>
        Task<CompanyDTO> CreateAsync(CompanyDTO companyDTO);

        /// <summary>
        ///         Update company.
        /// </summary>
        Task<CompanyDTO> UpdateAsync(CompanyDTO companyDTO);

        /// <summary>
        ///         Delete company.
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}