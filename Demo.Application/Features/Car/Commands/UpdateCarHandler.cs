using Demo.Application.Entities.Car.Requests;
using Demo.Persistence;
using Demo.Request.Handlers.Contracts;

namespace Demo.Application.Features.Car.Commands;

public class UpdateCarHandler : IHandler<UpdateCarRequest>
{
    private readonly ApplicationDbContext _context;

    public UpdateCarHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(UpdateCarRequest request, CancellationToken cancellationToken)
    {
        var car = _context.Car.FirstOrDefault(x => x.Id.Equals(request.id));

        if (car is not null)
        {
            car.Make = request.Make;
            car.Model = request.Model;
            car.Year = request.Year;
            car.Registration = request.Registration;
            car.Mileage = request.Mileage;

            var changes = await _context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to save changes for update to: {car}");
        }
        else
        {
            throw new Exception($"Could not find car with id: {request.id}");
        }
    }
}