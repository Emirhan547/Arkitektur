using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Business.Services.RoleAssignServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleAssignsController(IRoleAssignService _roleAssignService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AssignRoleDto>>> GetUserForRoleAssign(int id)
        {
           var response= await _roleAssignService.GetUserForRoleAssignAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult> AssignRole(List<AssignRoleDto>assignRoleDtos)
        {
            var response = await _roleAssignService.AssignRoleAsync(assignRoleDtos);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
