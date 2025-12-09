using Arkitektur.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeChooseViewComponent(IChooseService _chooseService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var response=await _chooseService.GetAllAsync();
            return View(response.Data);
        }
    }
}
