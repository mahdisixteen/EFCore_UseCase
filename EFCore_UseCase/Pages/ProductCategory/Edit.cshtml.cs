using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory Command;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int id)
        {
            Command = _productCategoryApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProductCategory command)
        {
_productCategoryApplication.Edit(command);
return RedirectToPage("./Index");
        }
    }
}
