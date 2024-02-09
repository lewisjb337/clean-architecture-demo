namespace Demo.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public Guid Key { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}