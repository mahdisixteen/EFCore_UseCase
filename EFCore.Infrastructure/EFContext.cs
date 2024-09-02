using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.EFCore
{
    public class EFContext :DbContext
    {
        public DbSet<Product> Products{ get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EFContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductMapping());
            //modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
