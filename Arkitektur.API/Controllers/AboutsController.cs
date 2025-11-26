using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultAboutDto>>> GetAll()
        {
            var response = await _aboutService.GetAllAsync();
            return response.IsSuccessful? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultAboutDto>>> GetById(int id)
        {
            var response = await _aboutService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create (CreateAboutDto createAboutDto)
        {
            var response = await _aboutService.CreateAsync(createAboutDto);
            return response.IsSuccessful ? Ok(response): BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateAboutDto updateAboutDto)
        {
            var response = await _aboutService.UpdateAsync(updateAboutDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var response = await _aboutService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

    }
}
