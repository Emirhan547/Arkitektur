using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.BannerDtos;
using Arkitektur.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class BannerController(IBannerService _bannerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _bannerService.GetAllAsync();
            return View(response.Data);
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto bannerDto)
        {
            await _bannerService.CreateAsync(bannerDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var response = await _bannerService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto bannerDto)
        {
            await _bannerService.UpdateAsync(bannerDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _bannerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
