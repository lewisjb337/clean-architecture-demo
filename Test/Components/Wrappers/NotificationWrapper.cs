using Demo.Models.Models;
using Demo.Test.Components.Services;

namespace Demo.Test.Components.Wrappers;

public class NotificationWrapper : INotificationWrapper
{
    private readonly NotificationsService _notificationService;

    public NotificationWrapper(NotificationsService notificationService)
    {
        _notificationService = notificationService;
    }

    public async void ExecuteWithNotificationAsync(Func<Task> action)
    {
        try
        {
            await action.Invoke();

            await _notificationService.PushNotificationAsync(new Notification
            {
                Title = "Success",
                Message = "Operation carried out successfully",
                ErrorDetails = string.Empty,
                BackgroundColourDark = "#2e7d32",
                BackgroundColourLight = "#43a047"
            });
        }
        catch (Exception e)
        {
            await _notificationService.PushNotificationAsync(new Notification
            {
                Title = "Error",
                Message = "Operation failed to be carried out",
                ErrorDetails = e.Message,
                BackgroundColourDark = "#e53935",
                BackgroundColourLight = "#f44336"
            });
        }
    }

    public async Task<T> ExecuteWithNotificationAsync<T>(Func<Task<T>> action)
    {
        try
        {
            var result = await action.Invoke();

            await _notificationService.PushNotificationAsync(new Notification
            {
                Title = "Success",
                Message = "Operation carried out successfully",
                ErrorDetails = string.Empty,
                BackgroundColourDark = "#2e7d32",
                BackgroundColourLight = "#43a047"
            });

            return result;
        }
        catch (Exception e)
        {
            await _notificationService.PushNotificationAsync(new Notification
            {
                Title = "Error",
                Message = "Operation failed to be carried out",
                ErrorDetails = e.Message,
                BackgroundColourDark = "#e53935",
                BackgroundColourLight = "#f44336"
            });

            return default;
        }
    }
}
