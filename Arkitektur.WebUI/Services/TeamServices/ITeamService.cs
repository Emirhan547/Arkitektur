using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamDtos;

namespace Arkitektur.WebUI.Services.TeamServices
{
    public interface ITeamService
    {
        Task<BaseResult<List<ResultTeamDto>>> GetAllAsync();
        Task<BaseResult<List<ResultTeamDto>>> GetTeamsWithSocialsAsync();
        Task<BaseResult<UpdateTeamDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTeamDto teamDto);
        Task<BaseResult<object>> UpdateAsync(UpdateTeamDto teamDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
