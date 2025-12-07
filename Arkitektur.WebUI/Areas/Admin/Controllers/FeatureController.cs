using Arkitektur.WebUI.DTOs.FeatureDtos;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IFeatureService _featureService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _featureService.GetAllAsync();
            return View(response.Data);
        }
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto featureDto)
        {
            await _featureService.CreateAsync(featureDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var response = await _featureService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto featureDto)
        {
            await _featureService.UpdateAsync(featureDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
