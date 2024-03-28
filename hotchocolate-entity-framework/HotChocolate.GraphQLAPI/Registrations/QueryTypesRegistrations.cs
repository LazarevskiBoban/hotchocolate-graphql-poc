using HotChocolate.Execution.Configuration;
using HotChocolate.GraphQLAPI.Scheme.Company;
using HotChocolate.GraphQLAPI.Scheme.Employee;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class QueryTypesRegistrations
    {
        public static IRequestExecutorBuilder AddExtendedQueryTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddType<CompanyQueries>();
            builder.AddType<EmployeeQueries>();

            return builder;
        }
    }
}