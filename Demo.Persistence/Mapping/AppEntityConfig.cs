using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Demo.Domain.Entities;

namespace Demo.Persistence.Mapping;

public class AppEntityConfig<TEntity> : IMapping, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        PostConfigure(builder);
    }

    public void ApplyConfiguration(ModelBuilder builder)
    {
        builder.ApplyConfiguration(this);
    }

    protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Key)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("SYSUTCDATETIME()");
        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()");
    }
}