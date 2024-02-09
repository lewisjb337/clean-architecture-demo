using Demo.Application.Entities.Car.Requests;
using Demo.Application.Entities.Car.Responses;
using Demo.Domain.Entities.Car;
using Demo.Persistence;
using Demo.Request.Handlers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Features.Car.Queries;

public class GetCarsHandler : IHandler<GetCarsRequest, IList<CarResponse>>
{
    private readonly ApplicationDbContext _context;

    public GetCarsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<CarResponse>> HandleAsync(GetCarsRequest request, CancellationToken cancellationToken)
    {
        return await _context.Car
            .Select(x => CarResponse.FromEntity(new CarEntity
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                Year = x.Year,
                Registration = x.Registration,
                Mileage = x.Mileage
            })).ToListAsync(cancellationToken);
    }
}