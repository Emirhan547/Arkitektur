using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public interface ITeamSocialService
    {
        Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync();
        Task<BaseResult<List<TeamSocialWithTeamNameSurnameDto>>> GetTeamSocialWithNameSurnameAsync();
        Task<BaseResult<ResultTeamSocialDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto teamSocialDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto teamSocialDto);
    }
}
