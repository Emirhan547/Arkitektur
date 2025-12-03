using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutSidebarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
