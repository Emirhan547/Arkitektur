using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class ContactController(IContactService _contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _contactService.GetAllAsync();
            return View(response.Data ?? new List<ResultContactDto>());
        }
    }
}
