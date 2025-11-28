using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.Services.ChooseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoosesController(IChooseService _chooseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultChooseDto>>> GetAll()
        {
            var response = await _chooseService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultChooseDto>>> GetById(int id)
        {
            var response = await _chooseService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateChooseDto createChooseDto)
        {
            var response = await _chooseService.CreateAsync(createChooseDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateChooseDto updateChooseDto)
        {
            var response = await _chooseService.UpdateAsync(updateChooseDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _chooseService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
