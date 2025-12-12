using Arkitektur.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeTestimonialViewComponent(ITestimonialService _testimonialService):ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        { 
            var response=await _testimonialService.GetAllAsync();
            return View(response.Data);
        }
    }
}
