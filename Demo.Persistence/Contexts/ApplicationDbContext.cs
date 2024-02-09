using Demo.Domain.Entities.Car;
using Demo.Persistence.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Demo.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CarEntity> Car { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var typeConfigurations = Assembly.GetExecutingAssembly()
            .GetTypes().Where(x => (x.BaseType?.IsGenericType ?? false)
                                   && x.BaseType.GetGenericTypeDefinition() == typeof(AppEntityConfig<>));

        foreach (var typeConfiguration in typeConfigurations)
        {
            var config = Activator.CreateInstance(typeConfiguration) as IMapping;
            config?.ApplyConfiguration(modelBuilder);
        }

        base.OnModelCreating(modelBuilder);
    }
}