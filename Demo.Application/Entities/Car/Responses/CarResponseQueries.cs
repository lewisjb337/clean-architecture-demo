using Demo.Domain.Entities.Car;

namespace Demo.Application.Entities.Car.Responses;

public class CarResponseQueries {}

public record CarResponse
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateOnly Year { get; set; }
    public string Registration { get; set; } = string.Empty;
    public int Mileage { get; set; }

    private CarResponse(CarEntity entity)
    {
        Id = entity.Id;
        Make = entity.Make;
        Model = entity.Model;
        Year = entity.Year;
        Registration = entity.Registration;
        Mileage = entity.Mileage;
    }

    public static CarResponse FromEntity(CarEntity entity) => new(entity);
}