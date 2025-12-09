using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;

namespace Arkitektur.WebUI.Services.TeamSocialServices
{
    public interface ITeamSocialService
    {
        Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync();
        Task<BaseResult<List<ResultTeamSocialDto>>> GetTeamSocialsWithNameSurnameAsync();
        Task<BaseResult<UpdateTeamSocialDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto teamSocialDto);
        Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto teamSocialDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
