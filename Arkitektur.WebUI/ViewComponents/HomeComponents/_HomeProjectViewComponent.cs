using Arkitektur.WebUI.Services.CategoryServices;

using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeProjectViewComponent(ICategoryService _categoryService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response=await _categoryService.GetCategoriesWithProjectsAsync();
            return View(response.Data);
        }
    }
}
