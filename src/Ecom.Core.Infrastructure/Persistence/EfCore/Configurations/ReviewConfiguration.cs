using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Primary Key
            builder.HasKey(r => r.Id);

            // Properties
            builder.Property(r => r.Rating).IsRequired();

            builder.Property(r => r.Title).HasMaxLength(200);

            builder.Property(r => r.Comment).HasMaxLength(1000);

            builder
                .Property(r => r.CreatedAt)
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
                .Property(r => r.DeletedAt)
                .HasColumnType("timestamp with time zone")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v =>
                        v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                            : (DateTimeOffset?)null
                );

            builder.Property(r => r.IsDeleted).HasDefaultValue(false);

            builder.Property(r => r.CreatedBy).IsRequired();

            builder.Property(r => r.UpdatedBy);

            builder.Property(r => r.DeletedBy);

            // Relationships
            builder
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Global Query Filter for Soft Delete
            builder.HasQueryFilter(r => !r.IsDeleted);

            // Indexes
            builder.HasIndex(r => r.ProductId);
            builder.HasIndex(r => r.IsDeleted);
            builder.HasIndex(r => r.CreatedAt);
            builder.HasIndex(r => r.UpdatedAt);
        }
    }
}
