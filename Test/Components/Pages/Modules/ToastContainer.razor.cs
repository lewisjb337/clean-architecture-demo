using Demo.Test.Components.Services;
using Microsoft.AspNetCore.Components;

namespace Test.Components.Pages.Modules;

public partial class ToastContainer
{
    [Inject]
    public NotificationsService NotificationsService { get; set; }

    [Parameter]
    public EventCallback EventCallback { get; set; }

    protected override void OnInitialized()
    {
        NotificationsService.OnCallback = EventCallback;
    }
}
