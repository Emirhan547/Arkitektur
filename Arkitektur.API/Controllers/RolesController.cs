using Arkitektur.Business.DTOs.RoleDtos;
using Arkitektur.Business.Services.RoleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RolesController(IRoleService _roleService) : ControllerBase
    {

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var response = await _roleService.CreateRole(roleDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _roleService.GetAllRolesAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
