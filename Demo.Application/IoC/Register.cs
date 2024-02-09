using Microsoft.Extensions.DependencyInjection;
using Demo.Request.Handlers.IoC;
using System.Reflection;

namespace Demo.Application.IoC;

public static class Register
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.UseRequestHandler(Assembly.GetExecutingAssembly());
    }
}