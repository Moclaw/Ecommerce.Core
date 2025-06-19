using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            // Primary Key
            builder.HasKey(pv => pv.Id);

            // Properties
            builder.Property(pv => pv.Sku).IsRequired();

            builder.HasIndex(pv => pv.Sku).IsUnique();

            builder.Property(pv => pv.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(pv => pv.Stock).HasDefaultValue(0);

            builder
                .Property(pv => pv.CreatedAt)
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
                .Property(pv => pv.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(pv => pv.IsDeleted).HasDefaultValue(false);

            builder.Property(pv => pv.CreatedBy).IsRequired();

            builder.Property(pv => pv.UpdatedBy);

            builder.Property(pv => pv.DeletedBy);

            // Indexes
            builder.HasIndex(pv => pv.ProductId);
            builder.HasIndex(pv => pv.Sku).IsUnique();
            builder.HasIndex(pv => pv.IsDeleted);
            builder.HasIndex(pv => pv.CreatedAt);
            builder.HasIndex(pv => pv.UpdatedAt);

            // Relationships
            builder
                .HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId);

            builder
                .HasMany(pv => pv.VariantAttributeValues)
                .WithOne(vav => vav.Variant)
                .HasForeignKey(vav => vav.VariantId);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(pv => !pv.IsDeleted);
        }
    }
}
