using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutTopBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
