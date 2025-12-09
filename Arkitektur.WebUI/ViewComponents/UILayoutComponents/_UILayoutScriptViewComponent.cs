using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.UILayoutComponent
{
    public class _UILayoutScriptViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

