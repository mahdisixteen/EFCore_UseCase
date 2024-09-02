using EFCore.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(z => z.Id);
            builder.Property(z => z.Name).HasMaxLength(255).IsRequired();

            builder.HasMany(z => z.Products)
                .WithOne(z => z.Category)
                .HasForeignKey(z => z.CategoryId);
        }
    }
}