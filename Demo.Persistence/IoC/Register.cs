using Demo.Persistence.Models;
using Demo.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Persistence.IoC;

public static class Register
{
    public static void RegisterPersistenceServices(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddScoped<UserContext>();
    }
}