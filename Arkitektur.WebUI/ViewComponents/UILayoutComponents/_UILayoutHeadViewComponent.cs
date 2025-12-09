using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}