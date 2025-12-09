using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Area.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class UserController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetAllUsersAsync();
            return View(response.Data);
        }
        public async Task<IActionResult> AssignRole(int Id)
        {
            var response = await _userService.GetUserForRoleAssignAsync(Id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        { 
                await _userService.AssignRoleAsync(model);
                return RedirectToAction("Index");

        }
    }
}