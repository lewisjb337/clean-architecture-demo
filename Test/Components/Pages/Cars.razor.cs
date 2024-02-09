using Demo.Application.Entities.Car.Requests;
using Demo.Application.Entities.Car.Responses;
using Demo.Request.Handlers.Concrete.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Test.Components.Pages.Modals.Cars;

namespace Test.Components.Pages;

[Authorize]
public partial class Cars
{
	[Inject]
	public required IRequestHandler Handler { get; set; }

	public IList<CarResponse>? CarsList { get; set; }

    public AddCarModal? AddModal { get; set; }
    public UpdateCarModal? UpdateModal { get; set; }
    public DeleteCarModal? DeleteModal { get; set; }

    private string _searchText = string.Empty;

    protected override async Task OnInitializedAsync()
	{
		await LoadData();
	}
	public async Task LoadData()
	{
		CarsList = await Handler.ExecuteAsync<GetCarsRequest, IList<CarResponse>>(new GetCarsRequest { }, default);
        
		StateHasChanged();
    }

    private async Task RefreshMe()
    {
        await LoadData();
        StateHasChanged();
    }
}