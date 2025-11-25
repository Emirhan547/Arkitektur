using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task<BaseResult<ResultAboutDto>>GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAboutDto createAboutDto);
        Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateAboutDto);
        Task<BaseResult<object>> DeleteAsync(int id);

    }
}
