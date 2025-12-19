using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles=Roles.Admin)]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();
            return View(abouts.Data);
        }
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAbout)
        {
            await _aboutService.CreateAsync(createAbout);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var response = await _aboutService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            await _aboutService.UpdateAsync(updateAbout);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}