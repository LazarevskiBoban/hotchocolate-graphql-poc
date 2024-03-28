using HotChocolate.Core.Services.Company;
using HotChocolate.Core.Services.Employee;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICompanyService, CompanyService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}