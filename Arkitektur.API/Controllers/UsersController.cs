using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService ) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
           var response = await _userService.CreateUserAsync(userDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
