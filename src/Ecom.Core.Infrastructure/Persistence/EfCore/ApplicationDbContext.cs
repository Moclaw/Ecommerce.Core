using EfCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ecom.Core.Infrastructure.Persistence.EfCore.Configurations;

namespace Ecom.Core.Infrastructure.Persistence.EfCore
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : BaseDbContext(options)
    {
        protected override Assembly ExecutingAssembly => typeof(ApplicationDbContext).Assembly;

        protected override Func<Type, bool> RegisterConfigurationsPredicate =>
            t => t.Namespace == typeof(ConfigurationFilter).Namespace;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
