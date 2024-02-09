using Demo.Application.Entities.Car.Requests;
using Demo.Application.Entities.Car.Responses;
using Demo.Domain.Entities.Car;
using Demo.Persistence;
using Demo.Request.Handlers.Contracts;

namespace Demo.Application.Features.Car.Commands;

public class CreateCarHandler : IHandler<CreateCarRequest, CarResponse>
{
    private readonly ApplicationDbContext _context;

    public CreateCarHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CarResponse> HandleAsync(CreateCarRequest request, CancellationToken cancellationToken)
    {
        var car = await _context.Car.AddAsync(new CarEntity
        {
            Make = request.Make,
            Model = request.Model,
            Year = request.Year,
            Registration = request.Registration,
            Mileage = request.Mileage
        }, cancellationToken);

        var changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes <= 0)
            throw new Exception($"Failed to save changes for creation of: {request}");

        return CarResponse.FromEntity(car.Entity);
    }
}