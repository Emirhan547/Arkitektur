using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController (IProjectService _projectService): ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultProjectDto>>> GetAll()
        {
            var response = await _projectService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [AllowAnonymous]
        [HttpGet("WithCategories")]
        public async Task<ActionResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var response = await _projectService.GetProjectsWithCategories();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultProjectDto>>> GetById(int id)
        {
            var response = await _projectService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            var response = await _projectService.CreateAsync(createProjectDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            var response = await _projectService.UpdateAsync(updateProjectDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _projectService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
