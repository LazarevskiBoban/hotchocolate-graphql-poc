using HotChocolate.Database;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class ContextRegistrations
    {
        public static void RegisterContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddPooledDbContextFactory<Context>(options =>
            {
                options.UseSqlServer(connectionString).LogTo(Console.WriteLine);
            });
        }
    }
}