using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TokenDtos;
using Arkitektur.WebUI.DTOs.UserDtos;

namespace Arkitektur.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResult<List<ResultUserDto>>> GetAllUsersAsync();
        Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id);
        Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto>assignRoleDtos);
        Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto model);
    }
}
