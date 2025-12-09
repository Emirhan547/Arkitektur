using Arkitektur.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeBannerViewComponent(IBannerService _bannerService) : ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var response=await _bannerService.GetAllAsync();
            return View(response.Data);
        }
    }
}