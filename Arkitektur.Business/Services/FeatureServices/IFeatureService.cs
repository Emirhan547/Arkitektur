using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFeatureDto createFeatureDto);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto updateFeatureDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
