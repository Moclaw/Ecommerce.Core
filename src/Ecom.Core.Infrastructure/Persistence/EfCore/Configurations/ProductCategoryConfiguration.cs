using Ecom.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Core.Infrastructure.Persistence.EfCore.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // Primary Key
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            // Indexes
            builder.HasIndex(pc => pc.ProductId);
            builder.HasIndex(pc => pc.CategoryId);

            // Relationships
            builder
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            builder
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // Global query filter
            builder.HasQueryFilter(pc => !pc.Category.IsDeleted && !pc.Product.IsDeleted);
        }
    }
}
