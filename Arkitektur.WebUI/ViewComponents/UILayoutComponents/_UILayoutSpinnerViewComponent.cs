using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutSpinnerViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
