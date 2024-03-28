using HotChocolate.Core.DataLoaders.Company;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class DataLoadersRegistrations
    {
        public static void RegisterDataLoaders(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<EmployeesDataLoader>();
        }
    }
}