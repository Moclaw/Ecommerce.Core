using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            // Primary Key
            builder.HasKey(av => av.Id);

            // Properties
            builder.Property(av => av.Value).IsRequired();

            builder.Property(av => av.AttributeId).IsRequired();

            builder
                .Property(av => av.CreatedAt)
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
                .Property(av => av.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(av => av.IsDeleted).HasDefaultValue(false);

            builder.Property(av => av.CreatedBy).IsRequired();

            builder.Property(av => av.UpdatedBy);

            builder.Property(av => av.DeletedBy);

            // Relationships
            builder.HasOne(av => av.Attribute).WithMany().HasForeignKey(av => av.AttributeId);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(av => !av.IsDeleted);

            // Indexes
            builder.HasIndex(av => av.AttributeId).HasDatabaseName("IX_AttributeValue_AttributeId");
            builder.HasIndex(av => av.Value).HasDatabaseName("IX_AttributeValue_Value");
            builder.HasIndex(av => av.IsDeleted).HasDatabaseName("IX_AttributeValue_IsDeleted");
        }
    }
}
