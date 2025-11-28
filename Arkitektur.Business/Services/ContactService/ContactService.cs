using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;
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

namespace Arkitektur.Business.Services.ContactService
{
    public class ContactService(IGenericRepository<Contact>_repository,IUnitOfWork _unitOfWork,IValidator<Contact>_validator) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto createContactDto)
        {
            var values = createContactDto.Adapt<Contact>();
            var validationResult = await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(values) : BaseResult<object>.Fail("Contact eklenemedi");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<object>.Fail("Contact Not Found");
            }
            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValue = values.Adapt<List<ResultContactDto>>();
            return BaseResult<List<ResultContactDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            if (values is null)
            {
                return BaseResult<ResultContactDto>.Fail("Contact Not Found");
            }
            var mappedValue = values.Adapt<ResultContactDto>();
            return BaseResult<ResultContactDto>.Success(mappedValue);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateContactDto)
        {
            var values = updateContactDto.Adapt<Contact>();
            var validationResult = await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Contact Failed");
        }
    }
}
