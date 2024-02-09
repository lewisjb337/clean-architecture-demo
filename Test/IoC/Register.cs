using Demo.Test.Components.Services;
using Demo.Test.Components.Wrappers;

namespace Demo.Test.IoC;

public static class Register
{
    public static void UseNotificationServices(this IServiceCollection services)
    {
        services.AddScoped<NotificationsService>();
        services.AddScoped<INotificationWrapper, NotificationWrapper>();
    }
}