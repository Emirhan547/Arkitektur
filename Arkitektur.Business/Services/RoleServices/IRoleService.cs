using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleDtos;

namespace Arkitektur.Business.Services.RoleServices;

public interface IRoleService
{
    Task<BaseResult<object>> CreateRole(CreateRoleDto roleDto);

    Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync();

}
