using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TeamServices
{
    public interface ITeamService
    {
        Task<BaseResult<List<ResultTeamDto>>> GetAllAsync();
        Task<BaseResult<List<ResultTeamDto>>> GetTeamWithSocialsAsync();
        Task<BaseResult<ResultTeamDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTeamDto teamDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateTeamDto teamDto);
    }
}
