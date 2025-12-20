using Arkitektur.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class ProjectController(IProjectService _projectService) : Controller
    {
        [HttpGet("/Project/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _projectService.GetDetailAsync(id);
            if (response is null || response.IsFailure || response.Data is null)
            {
                return NotFound();
            }

            return View(response.Data);
        }
    }
}