using HotChocolate.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Database
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}