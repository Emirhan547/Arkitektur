using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public interface ITeamSocialService:IGenericService<ResultTeamSocialDto,CreateTeamSocialDto,UpdateTeamSocialDto>
    {
        Task<BaseResult<List<TeamSocialWithTeamNameSurnameDto>>> GetTeamSocialWithNameSurnameAsync();

    }
}
