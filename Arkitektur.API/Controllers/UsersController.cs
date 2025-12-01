using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController(IUserService _userService ) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
           var response = await _userService.CreateUserAsync(userDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var response = await _userService.LoginAsync(loginDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
