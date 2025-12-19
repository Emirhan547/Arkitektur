using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;
using Arkitektur.WebUI.DTOs.ChooseDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.ChooseServices
{
    public interface IChooseService:IGenericService<ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto>
    {
        Task<BaseResult<List<ResultChooseDto>>> GetAllAsync();
        Task<BaseResult<UpdateChooseDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateChooseDto chooseDto);
        Task<BaseResult<object>> UpdateAsync(UpdateChooseDto chooseDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
