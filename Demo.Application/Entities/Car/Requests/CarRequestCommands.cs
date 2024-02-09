using Demo.Application.Entities.Car.Responses;
using Demo.Request.Handlers.Contracts;

namespace Demo.Application.Entities.Car.Requests;

public class CarRequestCommands {}

public record GetCarsRequest() : IRequest<IList<CarResponse>>;

public record GetCarByIdRequest(int id) : IRequest<IList<CarResponse>>;

public record CreateCarRequest(string Make, string Model, DateOnly Year, string Registration, int Mileage) : IRequest<CarResponse>;

public record UpdateCarRequest(int id, string Make, string Model, DateOnly Year, string Registration, int Mileage) : IRequest;

public record DeleteCarRequest(int id) : IRequest;