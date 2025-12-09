using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutNavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
