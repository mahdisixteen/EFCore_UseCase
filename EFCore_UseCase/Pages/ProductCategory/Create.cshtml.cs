using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    
    public class CreateModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost(CreateProductCategory command)
        {
            _productCategoryApplication.Create(command);
return RedirectToPage("./Index");
        }
    }
}
