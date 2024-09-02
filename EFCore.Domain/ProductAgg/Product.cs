using System;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.Domain.ProductAgg
{
    public class Product
    {
        public int Id { get; set; }
        public double UnitPrice { get; set; }
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public Product(double unitPrice, string name, int categoryId)
        {
            CreationDate = DateTime.Now;
            UnitPrice = unitPrice;
            Name = name;
            CategoryId = categoryId;
        }

        public void Edit(double unitPrice, string name, int categoryId)
        {
            UnitPrice = unitPrice;
            Name = name;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
