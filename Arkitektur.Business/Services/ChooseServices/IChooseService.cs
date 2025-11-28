using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ChooseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<BaseResult<List<ResultChooseDto>>> GetAllAsync();
        Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateChooseDto createChooseDto);
        Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateChooseDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
