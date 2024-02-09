using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence.Mapping;

public interface IMapping
{
    void ApplyConfiguration(ModelBuilder builder);
}