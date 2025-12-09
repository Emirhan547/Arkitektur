using Arkitektur.WebUI.Consts;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;
using Arkitektur.WebUI.Services.TeamServices;
using Arkitektur.WebUI.Services.TeamSocialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area(Area.Admin)]
    [Authorize(Roles=Roles.Admin)]
    public class TeamSocialController(ITeamSocialService _teamSocialService,ITeamService _teamService) : Controller
    {
        private async Task GetTeams()
        {
            var result = await _teamService.GetAllAsync();
            var teams = result.Data;
            ViewBag.teams = (from team in teams
                                  select new SelectListItem
                                  {
                                      Text = team.NameSurname,
                                      Value = team.Id.ToString()
                                  }).ToList();

        }
        public async Task<IActionResult> Index()
        {
            var teamSocials = await _teamService.GetTeamsWithSocialsAsync();
            return View(teamSocials.Data);
        }
        public async Task <IActionResult> CreateTeamSocial()
        {
            await GetTeams();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeamSocial(CreateTeamSocialDto createTeam)
        {
            await GetTeams();
            await _teamSocialService.CreateAsync(createTeam);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTeamSocial(int id)
        {
            await GetTeams();
            var response = await _teamSocialService.GetByIdAsync(id);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeamSocial(UpdateTeamSocialDto updateTeam)
        {
            await GetTeams();
            await _teamSocialService.UpdateAsync(updateTeam);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTeamSocial(int id)
        {
            await _teamSocialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
