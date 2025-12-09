using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.TeamDtos;
using Arkitektur.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Area.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class TeamController(ITeamService _teamService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response=await _teamService.GetAllAsync();
            return View(response.Data);
        }
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeam)
        {
            await _teamService.CreateAsync(createTeam);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var response = await _teamService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeam)
        {
            await _teamService.UpdateAsync(updateTeam);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
