using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class AuthController(IUserService _userService) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            await _userService.LoginAsync(model);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}