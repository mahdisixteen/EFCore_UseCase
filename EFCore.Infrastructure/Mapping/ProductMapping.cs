using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(z => z.Id);
            builder.Property(z => z.Name).HasMaxLength(255).IsRequired();

            builder.HasOne(z => z.Category)
                .WithMany(z => z.Products)
                .HasForeignKey(z => z.CategoryId);
        }
    }
}
