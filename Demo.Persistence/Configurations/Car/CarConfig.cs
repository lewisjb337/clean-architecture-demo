using Demo.Domain.Entities.Car;
using Demo.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Persistence.Configurations.Car;

internal class CarConfig : AppEntityConfig<CarEntity>
{
    protected override void PostConfigure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.ToTable("Cars");
        base.PostConfigure(builder);
    }
}