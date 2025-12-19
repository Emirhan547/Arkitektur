using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.TeamServices
{
    public interface ITeamService:IGenericService<ResultTeamDto,CreateTeamDto,UpdateTeamDto>
    {
        Task<BaseResult<List<ResultTeamDto>>> GetTeamsWithSocialsAsync();

    }
}
