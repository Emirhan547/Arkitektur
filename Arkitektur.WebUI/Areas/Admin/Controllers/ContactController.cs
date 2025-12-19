using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class ContactController(IContactService _contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _contactService.GetAllAsync();
            return View(response.Data);
        }
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto contactDto)
        {
            await _contactService.CreateAsync(contactDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateContact(int id)
        {
            var response = await _contactService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto contactDto)
        {
            await _contactService.UpdateAsync(contactDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
