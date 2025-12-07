using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.FeatureDtos;

namespace Arkitektur.WebUI.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<UpdateFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFeatureDto featureDto);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto featureDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
