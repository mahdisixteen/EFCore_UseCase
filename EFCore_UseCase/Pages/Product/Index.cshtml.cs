using System.Collections.Generic;
using EFCore.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IProductApplication productApplication;

        public IndexModel(IProductApplication _productApplication)
        {
            productApplication = _productApplication;
        }
        public void OnGet(ProductSearchModel searchModel)
        {
            Products = productApplication.Search(searchModel);
        }
    }
}
