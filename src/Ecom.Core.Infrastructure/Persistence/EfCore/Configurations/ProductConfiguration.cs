using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Slug).IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(p => p.SalePrice).HasColumnType("decimal(18,2)");

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(v => v.UtcDateTime, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                .IsRequired();

            builder
                   .Property(a => a.UpdatedAt)
                   .HasColumnType("timestamp with time zone")
                   .HasConversion(
                       v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                       v => v.HasValue
                           ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                           : null
                   )
                   .IsRequired(false);

            builder
                .Property(p => p.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.Property(p => p.CreatedBy).IsRequired();

            builder.Property(p => p.UpdatedBy);

            builder.Property(p => p.DeletedBy);

            // Indexes
            builder.HasIndex(p => p.Slug).IsUnique();
            builder.HasIndex(p => p.IsDeleted);
            builder.HasIndex(p => p.CreatedAt);
            builder.HasIndex(p => p.UpdatedAt);

            // Relationships
            builder
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);

            builder
                .HasMany(p => p.Variants)
                .WithOne(v => v.Product)
                .HasForeignKey(v => v.ProductId);

            builder.HasMany(p => p.Images).WithOne(i => i.Product).HasForeignKey(i => i.ProductId);

            builder.HasMany(p => p.Reviews).WithOne(r => r.Product).HasForeignKey(r => r.ProductId);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
