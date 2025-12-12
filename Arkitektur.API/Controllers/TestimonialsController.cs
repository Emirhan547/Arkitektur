using Arkitektur.Business.DTOs.TestimonialDtos;
using Arkitektur.Business.Services.TestimonialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController (ITestimonialService _testimonialService): ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultTestimonialDto>>> GetAll()
        {
            var response = await _testimonialService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ResultTestimonialDto>>> GetById(int id)
        {
            var response = await _testimonialService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            var response = await _testimonialService.CreateAsync(createTestimonialDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var response = await _testimonialService.UpdateAsync(updateTestimonialDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _testimonialService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
