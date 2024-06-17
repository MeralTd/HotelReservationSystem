using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("created_date").HasColumnType("timestamp with time zone").HasDefaultValueSql("now()").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date").HasColumnType("timestamp with time zone");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date").HasColumnType("timestamp with time zone");
    }
}
