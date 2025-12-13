using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.RoleAssignServices
{
    public class RoleAssignService(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : IRoleAssignService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
        {
            var userId = assignRoleDtos.Select(x=>x.UserId).FirstOrDefault();
            var user=await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return BaseResult<object>.Fail("User Not Found");
            }
            foreach (var assignRole in assignRoleDtos)
            {
                if (assignRole.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, assignRole.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, assignRole.RoleName);
                }
                    
            }
            return BaseResult<object>.Success(new {Message="Role Assign Succesfully"});
        }

        public async Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id)
        {
            var user=await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                return BaseResult<List<AssignRoleDto>>.Fail("User Not Found");
            }
            var roles =await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleAssignments = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                var assignRoleDto = new AssignRoleDto
                {
                    UserId = user.Id,
                    FullName = user.FirstName+" "+user.LastName,
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExist = userRoles.Contains(role.Name)
                };
                roleAssignments.Add(assignRoleDto);
            }
            return BaseResult<List<AssignRoleDto>>.Success(roleAssignments);
        }
    }
}
