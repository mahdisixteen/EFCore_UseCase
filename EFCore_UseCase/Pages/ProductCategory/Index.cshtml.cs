using System.Collections.Generic;
using EFCore.Application;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(string name)
        {
            ProductCategories = _productCategoryApplication.Search(name);
        }
    }
}
