using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.BannerDtos;

namespace Arkitektur.WebUI.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<UpdateBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto bannerDto);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto bannerDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
