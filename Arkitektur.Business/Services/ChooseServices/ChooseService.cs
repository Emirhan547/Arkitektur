using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ChooseServices
{
    public class ChooseService(IGenericRepository<Choose>_repository,IUnitOfWork _unitOfWork,IValidator<Choose>_validator) : IChooseService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto createChooseDto)
        {
            var values = createChooseDto.Adapt<Choose>();
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
                return BaseResult<object>.Fail("Choose Not Found");
            }
            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValue = values.Adapt<List<ResultChooseDto>>();
            return BaseResult<List<ResultChooseDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            if (values is null)
            {
                return BaseResult<ResultChooseDto>.Fail("Choose Not Found");
            }
            var mappedValue = values.Adapt<ResultChooseDto>();
            return BaseResult<ResultChooseDto>.Success(mappedValue);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateChooseDto)
        {
            var values = updateChooseDto.Adapt<Choose>();
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
