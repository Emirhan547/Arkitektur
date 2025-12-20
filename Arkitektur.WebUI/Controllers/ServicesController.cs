using Arkitektur.WebUI.DTOs.FeatureDtos;
using Arkitektur.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class ServicesController(IFeatureService featureService) : Controller
    {
        private readonly IFeatureService _featureService = featureService;

        public async Task<IActionResult> Index()
        {
            var response = await _featureService.GetAllAsync();
            return View(response.Data ?? new List<ResultFeatureDto>());
        }
    }
}