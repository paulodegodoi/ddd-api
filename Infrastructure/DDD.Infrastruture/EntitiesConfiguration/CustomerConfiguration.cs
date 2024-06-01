using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastruture.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(c => c.Document).IsUnique();
        builder.Property(c => c.Document).HasMaxLength(14).IsRequired();
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
    }
}