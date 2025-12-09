using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Services.TeamSocialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamSocialsController(ITeamSocialService _teamSocialService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultTeamSocialDto>>> GetAll()
        {
            var response = await _teamSocialService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [AllowAnonymous]
        [HttpGet("WithNameSurname")]
        public async Task<ActionResult<List<ResultTeamSocialDto>>> GetAllWithNameSurname()
        {
            var response = await _teamSocialService.GetTeamSocialWithNameSurnameAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultTeamSocialDto>>> GetById(int id)
        {
            var response = await _teamSocialService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamSocialDto createTeamSocialDto)
        {
            var response = await _teamSocialService.CreateAsync(createTeamSocialDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeamSocialDto updateTeamSocialDto)
        {
            var response = await _teamSocialService.UpdateAsync(updateTeamSocialDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _teamSocialService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
