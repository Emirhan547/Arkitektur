using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.TeamSocialServices
{
    public interface ITeamSocialService:IGenericService<ResultTeamSocialDto,CreateTeamSocialDto,UpdateTeamSocialDto>
    {
        Task<BaseResult<List<ResultTeamSocialDto>>> GetTeamSocialsWithNameSurnameAsync();

    }
}
