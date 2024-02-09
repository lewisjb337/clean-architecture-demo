namespace Demo.Models.Responses;

public class CarResponse
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateOnly Year { get; set; }
    public string Registration { get; set; } = string.Empty;
    public int Mileage { get; set; }
}