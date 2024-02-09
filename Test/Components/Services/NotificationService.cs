using Demo.Models.Models;
using Microsoft.AspNetCore.Components;

namespace Demo.Test.Components.Services;

public class NotificationsService : INotificationService
{
    public List<Notification> Notifications { get; set; } = new();

    public EventCallback OnCallback { get; set; }

    public async Task PushNotificationAsync(Notification notification)
    {
        Notifications.Add(notification);
        await OnCallback.InvokeAsync();
    }

    public async Task DeleteNotificationAsync(Notification notification)
    {
        Notifications.Remove(notification);
        await OnCallback.InvokeAsync();
    }
}
