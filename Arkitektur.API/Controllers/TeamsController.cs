using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.Services.TeamServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(ITeamService _teamService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultTeamDto>>> GetAll()
        {
            var response = await _teamService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [AllowAnonymous]
        [HttpGet("WithSocials")]
        public async Task<ActionResult<List<ResultTeamDto>>> GetAllWithSocials()
        {
            var response = await _teamService.GetTeamWithSocialsAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultTeamDto>>> GetById(int id)
        {
            var response = await _teamService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto createAboutDto)
        {
            var response = await _teamService.CreateAsync(createAboutDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeamDto updateAboutDto)
        {
            var response = await _teamService.UpdateAsync(updateAboutDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _teamService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
