using EFCore.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        ProductCategory Get(int Id);
        bool Exists(string name);
        void Create(ProductCategory productCategory);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();
        void SaveChanges();

    }
}
