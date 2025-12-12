using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class AppointmentController(IAppointmentService _appointmentService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>MakeAppointment(CreateAppointmentDto createAppointmentDto)
        {
            await _appointmentService.CreateAsync(createAppointmentDto);
            return NoContent();
        }

    }
}
