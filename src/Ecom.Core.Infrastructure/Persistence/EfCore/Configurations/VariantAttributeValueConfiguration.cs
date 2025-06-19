using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class VariantAttributeValueConfiguration
        : IEntityTypeConfiguration<VariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<VariantAttributeValue> builder)
        {
            // Primary Key
            builder.HasKey(vav => new { vav.VariantId, vav.AttributeValueId });

            // Properties
            builder.Property(vav => vav.VariantId).IsRequired();

            builder.Property(vav => vav.AttributeValueId).IsRequired();

            builder
                .Property(vav => vav.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(v => v.UtcDateTime, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder                .Property(a => a.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : (DateTime?)null
                )
                .IsRequired(false);

            builder
                .Property(vav => vav.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(vav => vav.IsDeleted).HasDefaultValue(false);

            builder.Property(vav => vav.CreatedBy).IsRequired();

            builder.Property(vav => vav.UpdatedBy);

            builder.Property(vav => vav.DeletedBy);

            // Indexes
            builder.HasIndex(vav => vav.VariantId);
            builder.HasIndex(vav => vav.AttributeValueId);
            builder.HasIndex(vav => vav.IsDeleted);
            builder.HasIndex(vav => vav.CreatedAt);
            builder.HasIndex(vav => vav.UpdatedAt);

            // Relationships
            builder
                .HasOne(vav => vav.Variant)
                .WithMany(pv => pv.VariantAttributeValues)
                .HasForeignKey(vav => vav.VariantId);

            builder
                .HasOne(vav => vav.AttributeValue)
                .WithMany()
                .HasForeignKey(vav => vav.AttributeValueId);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(vav => !vav.IsDeleted);
        }
    }
}
