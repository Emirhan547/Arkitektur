using Arkitektur.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.HomeComponents
{
    public class _HomeTeamViewComponent(ITeamService _teamService):ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var response=await _teamService.GetTeamsWithSocialsAsync();
            return View(response.Data);
        }
    }
}
