using HotChocolate.Execution.Configuration;
using HotChocolate.GraphQLAPI.Scheme.Company;
using HotChocolate.GraphQLAPI.Scheme.Employee;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class MutationTypeRegistrations
    {
        public static IRequestExecutorBuilder AddExtendedMutationTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddType<CompanyMutations>();
            builder.AddType<EmployeeMutations>();

            return builder;
        }
    }
}