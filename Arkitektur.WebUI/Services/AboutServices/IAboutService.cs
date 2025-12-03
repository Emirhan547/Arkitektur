using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AboutDtos;

namespace Arkitektur.WebUI.Services.AboutServices
{
    public interface IAboutService
    {
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAboutDto aboutDto);
        Task<BaseResult<object>> UpdateAsync(UpdateAboutDto aboutDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
