using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ChooseDtos;

namespace Arkitektur.WebUI.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<BaseResult<List<ResultChooseDto>>> GetAllAsync();
        Task<BaseResult<UpdateChooseDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateChooseDto chooseDto);
        Task<BaseResult<object>> UpdateAsync(UpdateChooseDto chooseDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
