using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _aboutService.GetAllAsync();
            return View(response.Data ?? new List<ResultAboutDto>());
        }
    }
    }