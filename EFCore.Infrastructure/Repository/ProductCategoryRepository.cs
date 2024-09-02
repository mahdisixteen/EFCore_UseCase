using System.Collections.Generic;
using System.Linq;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository :  IProductCategoryRepository
    {
        private readonly EFContext efContext;

        public ProductCategoryRepository(EFContext _efContext)
        {
            efContext = _efContext;
        }

        public ProductCategory Get(int Id)
        {
            return efContext.ProductCategories.FirstOrDefault(z => z.Id == Id);
        }

        public bool Exists(string name)
        {
            return efContext.ProductCategories.Any(z => z.Name == name);
        }


        public void Create(ProductCategory productCategory)
        {
            efContext.ProductCategories.Add(productCategory);
            SaveChanges();
        }

        public EditProductCategory GetDetails(int id)
        {
            return efContext.ProductCategories.Select(z => new EditProductCategory
            {
                Id = z.Id,
                Name = z.Name
            }).FirstOrDefault(z => z.Id == id);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = efContext.ProductCategories.Select(z => new ProductCategoryViewModel()
            {
                Id = z.Id,
                Name = z.Name,
                CreationDate = z.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(z => z.Name.Contains(name));

            return query.OrderBy(z => z.CreationDate).ToList();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return efContext.ProductCategories.Select(z => new ProductCategoryViewModel
            {
                Id = z.Id,
                Name = z.Name
            }).ToList();
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }
    }
}

