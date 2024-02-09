using Demo.Application.Entities.Car.Requests;
using Demo.Application.Entities.Car.Responses;
using Demo.Request.Handlers.Concrete.Interfaces;
using Test.Components.Pages.Modules;
using Microsoft.AspNetCore.Components;
using Demo.Test.Components.Wrappers;

namespace Test.Components.Pages.Modals.Cars;

public partial class AddCarModal
{
    [Inject]
    public required IRequestHandler Handler { get; set; }

    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    [Inject]
    public INotificationWrapper NotificationWrapper { get; set; }

    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateOnly Year { get; set; }
    public string Registration { get; set; } = string.Empty;
    public int Mileage { get; set; }

    public Modal _modal;

    private bool isDisabled = false;

    public async Task Open()
    {
        _modal.ShowModal();

        StateHasChanged();
    }

    private async Task AddCar(CancellationToken cancellationToken = default)
    {
        isDisabled = true;

        var request = new CreateCarRequest(Make, Model, Year, Registration, Mileage);

        await NotificationWrapper.ExecuteWithNotificationAsync(async() => await Handler.ExecuteAsync<CreateCarRequest, CarResponse>(request, cancellationToken));

        await ClearFields();

        await _modal.Close();

        isDisabled = false;
    }

    public async Task ClearFields()
    {
        Make = string.Empty;
        Model = string.Empty;
        Year = DateOnly.Parse("01/01/0001");
        Registration = string.Empty;
        Mileage = 0;
    }
}
