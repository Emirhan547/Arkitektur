using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeAppointmentViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
