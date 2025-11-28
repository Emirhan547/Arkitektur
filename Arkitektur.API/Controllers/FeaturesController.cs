
using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.Business.Services.FeatureServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService _featureService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultFeatureDto>>> GetAll()
        {
            var response = await _featureService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultFeatureDto>>> GetById(int id)
        {
            var response = await _featureService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            var response = await _featureService.CreateAsync(createFeatureDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            var response = await _featureService.UpdateAsync(updateFeatureDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _featureService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
