using Demo.Application.Entities.Car.Requests;
using Demo.Request.Handlers.Concrete.Interfaces;
using Demo.Test.Components.Wrappers;
using Microsoft.AspNetCore.Components;
using Test.Components.Pages.Modules;

namespace Test.Components.Pages.Modals.Cars;

public partial class DeleteCarModal
{
    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    private Modal? _modal;

    [Inject]
    public required IRequestHandler Handler { get; set; }

    [Inject]
    public INotificationWrapper NotificationWrapper { get; set; }

    public int Id { get; set; }

    public async Task Open(int id)
    {
        Id = id;

        _modal.ShowModal();

        StateHasChanged();
    }

    public async Task Delete()
    {
        var request = new DeleteCarRequest(Id);

        NotificationWrapper.ExecuteWithNotificationAsync(async() => await Handler.ExecuteAsync(request, default));

        _modal.Close();
    }
}