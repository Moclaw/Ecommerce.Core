using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Primary Key
            builder.HasKey(pi => pi.Id);

            // Properties
            builder.Property(pi => pi.ProductId).IsRequired();

            builder.Property(pi => pi.ImageUrl).IsRequired();

            builder.Property(pi => pi.Position).HasDefaultValue(0);

            builder
                .Property(pi => pi.CreatedAt)
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
                .Property(pi => pi.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(pi => pi.IsDeleted).HasDefaultValue(false);

            builder.Property(pi => pi.CreatedBy).IsRequired();

            builder.Property(pi => pi.UpdatedBy);

            builder.Property(pi => pi.DeletedBy);

            // Relationships
            builder
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId);

            // Indexes
            builder.HasIndex(pi => pi.ProductId);
            builder.HasIndex(pi => pi.IsDeleted);
            builder.HasIndex(pi => pi.CreatedAt);
            builder.HasIndex(pi => pi.UpdatedAt);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(pi => !pi.IsDeleted);
        }
    }
}
