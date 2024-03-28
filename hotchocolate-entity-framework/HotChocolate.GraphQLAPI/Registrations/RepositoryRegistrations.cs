using HotChocolate.Core.RepositoryContracts;
using HotChocolate.Core.RepositoryContracts.Generic;
using HotChocolate.Database.Repositories;
using HotChocolate.Database.Repositories.Generic;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class RepositoryRegistrations
    {
        public static void RegisterRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}