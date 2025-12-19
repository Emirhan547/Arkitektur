using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.BannerDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.BannerServices
{
    public interface IBannerService:IGenericService<ResultBannerDto,CreateBannerDto,UpdateBannerDto>
    {
        
    }
}
