using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]


public class AboutsController(IAboutService aboutService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<ResultAboutDto>>> GetAll()
    {
        var response = await aboutService.GetAllAsync();

        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultAboutDto>> GetById(int id)
    {
        var response = await aboutService.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAboutDto aboutDto)
    {
        var response = await aboutService.CreateAsync(aboutDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
    {
        var response = await aboutService.UpdateAsync(aboutDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await aboutService.DeleteAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }



}