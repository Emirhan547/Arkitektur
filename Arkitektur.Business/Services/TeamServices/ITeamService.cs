using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TeamServices
{
    public interface ITeamService:IGenericService<ResultTeamDto,CreateTeamDto,UpdateTeamDto>
    {
        Task<BaseResult<List<ResultTeamDto>>> GetTeamWithSocialsAsync();

    }
}
