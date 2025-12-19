using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.DataAccess.Repositories.FeatureRepositories;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.FeatureServices
{
    public class FeatureService(IFeatureRepository _repository,IUnitOfWork _unitOfWork,IValidator<Feature>_validator):IFeatureService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto createFeatureDto)
        {
            var values = createFeatureDto.Adapt<Feature>();
            var validationResult = await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(values) : BaseResult<object>.Fail("Create Failded)");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<object>.Fail("Feature Not Found");
            }
            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValue = values.Adapt<List<ResultFeatureDto>>();
            return BaseResult<List<ResultFeatureDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            if (values is null)
            {
                return BaseResult<ResultFeatureDto>.Fail("Feature Not Found");
            }
            var mappedValue = values.Adapt<ResultFeatureDto>();
            return BaseResult<ResultFeatureDto>.Success(mappedValue);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = updateFeatureDto.Adapt<Feature>();
            var validationResult = await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Choose Failed");
        }
    }
}
