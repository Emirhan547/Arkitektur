using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleDtos;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole>_roleManager) : IRoleService
    {
        public async Task<BaseResult<object>> CreateRole(CreateRoleDto roleDto)
        {
            var role=roleDto.Adapt<AppRole>();
            var result=await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }
            return BaseResult<object>.Success(new{Message="Role Created Succesfully." });
        }

        public async Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync()
        {
            var roles=_roleManager.Roles.ToListAsync();
            var resultRoles=roles.Result.Adapt<List<ResultRoleDto>>();
            return BaseResult<List<ResultRoleDto>>.Success(resultRoles);
        }
    }
}
