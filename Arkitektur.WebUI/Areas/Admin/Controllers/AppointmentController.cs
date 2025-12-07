using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController(IAppointmentService _appointmentService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _appointmentService.GetAllAsync();
            return View(response.Data);
        }
        public async Task<IActionResult> AppointmentDetails(int id)
        {
            var response = await _appointmentService.GetByIdAsync(id);
            return View(response.Data);
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ApproveAppointment(int id)
        {
            await _appointmentService.ApproveAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _appointmentService.CancelAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}