using System.Collections.Generic;
using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;

namespace EFCore.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductApplication(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public void Create(CreateProduct command)
        {
            if (productRepository.Exists(command.Name,command.CategoryId))
                return;

            var product = new Product(command.UnitPrice, command.Name, command.CategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
            
        }

        public void Edit(EditProduct command)
        {
            var product = productRepository.Get(command.Id);
            if (product == null)
                return;
            product.Edit(command.UnitPrice,command.Name,command.Id);
            productRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = productRepository.Get(id);
            if (product == null)
                return;
            product.Remove();
            productRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = productRepository.Get(id);
            if (product == null)
                return;
            product.Restore();
            productRepository.SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            return productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
