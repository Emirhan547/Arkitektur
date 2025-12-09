using Arkitektur.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeFeatureViewComponent(IFeatureService _featureService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var response=await _featureService.GetAllAsync();
            return View(response.Data);
        }
    }
}
