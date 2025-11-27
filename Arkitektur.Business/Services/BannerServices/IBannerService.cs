using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.BannerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
