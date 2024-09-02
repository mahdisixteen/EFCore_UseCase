using System.Collections.Generic;
using System.Linq;
using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFContext efContext;

        public ProductRepository(EFContext _efContext)
        {
            efContext = _efContext;
        }

        public Product Get(int id)
        {
            return efContext.Products.FirstOrDefault(z => z.Id == id);
        }

        public bool Exists(string name, int categoryId)
        {
            return efContext.Products.Any(z => z.Name == name && z.Id == categoryId);
        }

        public void Create(Product product)
        {
            efContext.Products.Add(product);
            SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            return efContext.Products.Select(z => new EditProduct
            {
                Id = z.Id,
                CategoryId = z.CategoryId,
                Name = z.Name,
                UnitPrice = z.UnitPrice

            }).FirstOrDefault(z => z.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = efContext.Products
                .Include(z=>z.Category)
                .Select(z => new ProductViewModel
            {
                CreationDate = z.CreationDate.ToString(),
                Id = z.Id,
                IsRemoved = z.IsRemoved,
                Name = z.Name,
                UnitPrice = z.UnitPrice,
                Category = z.Category.Name
                });
            if (searchModel.IsRemoved)
                query = query.Where(z => z.IsRemoved == true);

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(z => z.Name.Contains(searchModel.Name));

            return query.OrderByDescending(z => z.Id).ToList();

        }
        public void SaveChanges()
        {
            efContext.SaveChanges();
        }
    }
}
