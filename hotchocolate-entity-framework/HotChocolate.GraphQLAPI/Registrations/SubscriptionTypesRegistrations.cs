using HotChocolate.Execution.Configuration;
using HotChocolate.GraphQLAPI.Scheme.Company;
using HotChocolate.GraphQLAPI.Scheme.Employee;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class SubscriptionTypesRegistrations
    {
        public static IRequestExecutorBuilder AddExtendedSubscriptionTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddType<CompanySubscriptions>();
            builder.AddType<EmployeeSubscriptions>();

            return builder;
        }
    }
}