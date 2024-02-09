using Demo.Models.Models;
using Demo.Test.Components.Services;
using Microsoft.AspNetCore.Components;

namespace Test.Components.Pages.Modules;

public partial class Toast
{
    [Inject]
    NotificationsService NotificationsService { get; set; }

    [Parameter]
    public Notification Notification { get; set; }

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public string Message { get; set; } = string.Empty;

    [Parameter]
    public string BackgroundColourDark { get; set; } = string.Empty;
    public string BackgroundColourLight { get; set; } = string.Empty;

    private async void DeleteNotification()
    {
        await NotificationsService.DeleteNotificationAsync(Notification);
    }
}