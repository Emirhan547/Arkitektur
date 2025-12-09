using Arkitektur.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeAboutViewComponent(IAboutService _aboutService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var response=await _aboutService.GetAllAsync();
            return View(response.Data);
        }
    }
}
