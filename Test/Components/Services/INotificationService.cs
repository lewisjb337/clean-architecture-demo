using Demo.Models.Models;
using Microsoft.AspNetCore.Components;

namespace Demo.Test.Components.Services;

public interface INotificationService
{
    public List<Notification> Notifications { get; set; }

    public EventCallback OnCallback { get; set; }

    Task PushNotificationAsync(Notification notification);

    Task DeleteNotificationAsync(Notification notification);
}