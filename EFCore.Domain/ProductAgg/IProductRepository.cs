using System.Collections.Generic;
using EFCore.Application.Contracts.Product;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        bool Exists(string name, int categoryId);
        void Create(Product product);
        EditProduct GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        void SaveChanges();
    }
}
