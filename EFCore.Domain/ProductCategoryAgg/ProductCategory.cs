using System;
using System.Collections.Generic;
using EFCore.Domain.ProductAgg;

namespace EFCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Product> Products { get; set; }

        public ProductCategory(string name)
        {
            CreationDate = DateTime.Now;
            Name = name;
            Products = new List<Product>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }

}