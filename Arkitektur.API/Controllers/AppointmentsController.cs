using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmentService _appointmentService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto appointmentDto)
        {
            var response = await _appointmentService.CreateAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<ResultAppointmentDto>>> GetAll()
        {
            var response = await _appointmentService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAppointmentDto>> GetById(int id)
        {
            var response = await _appointmentService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDto appointmentDto)
        {
            var response = await _appointmentService.UpdateAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _appointmentService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPatch("Approve")]
        public async Task<IActionResult> Approve(UpdateAppointmentDto appointmentDto)
        {
            var response = await _appointmentService.ApproveAppointmentAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPatch("Cancel")]
        public async Task<IActionResult> Cancel(UpdateAppointmentDto appointmentDto)
        {
            var response = await _appointmentService.CancelAppointmentAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

    }
}