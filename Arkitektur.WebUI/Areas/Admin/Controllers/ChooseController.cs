using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.ChooseDtos;
using Arkitektur.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class ChooseController(IChooseService _chooseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _chooseService.GetAllAsync();
            return View(response.Data);
        }
        public IActionResult CreateChoose()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateChoose(CreateChooseDto chooseDto)
        {
            await _chooseService.CreateAsync(chooseDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateChoose(int id)
        {
            var response = await _chooseService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateChoose(UpdateChooseDto chooseDto)
        {
            await _chooseService.UpdateAsync(chooseDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteChoose(int id)
        {
            await _chooseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
