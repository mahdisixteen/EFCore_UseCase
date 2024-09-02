using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_UseCase.Pages.Product
{
    public class EditModel : PageModel
    {
        public SelectList ProductCategories;
        public EditProduct Command;
        private readonly IProductCategoryApplication productCategoryApplication;
        private readonly IProductApplication productApplication;

        public EditModel(IProductApplication _productApplication, IProductCategoryApplication _productCategoryApplication)
        {
            productApplication = _productApplication;
            productCategoryApplication = _productCategoryApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
            Command = productApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
productApplication.Edit(command);
return RedirectToPage("./Index");
        }
    }
}
