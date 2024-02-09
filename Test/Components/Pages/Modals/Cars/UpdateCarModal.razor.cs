using Demo.Application.Entities.Car.Requests;
using Demo.Application.Entities.Car.Responses;
using Demo.Request.Handlers.Concrete.Interfaces;
using Demo.Test.Components.Wrappers;
using Microsoft.AspNetCore.Components;
using Test.Components.Pages.Modules;

namespace Test.Components.Pages.Modals.Cars;

public partial class UpdateCarModal
{
    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    private Modal? _modal;

    [Inject]
    public required IRequestHandler Handler { get; set; }

    [Inject]
    public INotificationWrapper NotificationWrapper { get; set; }

    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateOnly Year { get; set; }
    public string Registration { get; set; } = string.Empty;
    public int Mileage { get; set; }

    public IList<CarResponse>? Cars { get; set; }

    public async Task Open(int id)
    {
        Id = id;

        await LoadData();

        _modal.ShowModal();

        StateHasChanged();
    }

    public async Task LoadData()
    {
        Cars = await Handler.ExecuteAsync<GetCarByIdRequest, IList<CarResponse>>(new GetCarByIdRequest(Id), default);

        Id = Cars.FirstOrDefault().Id;
        Make = Cars.FirstOrDefault().Make;
        Model = Cars.FirstOrDefault().Model;
        Year = Cars.FirstOrDefault().Year;
        Registration = Cars.FirstOrDefault().Registration;
        Mileage = Cars.FirstOrDefault().Mileage;

        StateHasChanged();
    }

    public async Task Add(CancellationToken cancellationToken = default)
    {
        var request = new UpdateCarRequest
        (
            Id,
            Make,
            Model,
            Year,
            Registration,
            Mileage
        );

        NotificationWrapper.ExecuteWithNotificationAsync(async () => await Handler.ExecuteAsync(request, cancellationToken));

        _modal.Close();
    }
}