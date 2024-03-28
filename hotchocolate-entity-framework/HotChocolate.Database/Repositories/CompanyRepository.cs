using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.RepositoryContracts;
using HotChocolate.Database.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Database.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbContextFactory<Context> context) : base(context)
        {
        }
    }
}