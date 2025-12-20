using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.Repositories.ProjectRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ProjectServices
{
    public class ProjectService(IProjectRepository _repository,IUnitOfWork _unitOfWork,IValidator<Project>_validator) : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto)
        {
            var values= createProjectDto.Adapt<Project>();
            var validationResult= await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(values);
            var result= await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(values) : BaseResult<object>.Fail("Project eklenemedi");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<object>.Fail("Project Not Found");
            }
            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValue = values.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(mappedValue);
        }

        public async  Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
            var values = await _repository.GetByIdWithCategoryAsync(id);
            if (values is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Project Not Found");
            }
            var mappedValue = values.Adapt<ResultProjectDto>();
            return BaseResult<ResultProjectDto>.Success(mappedValue);
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var products = await _repository.GetProjectsWithCategoriesAsync();
            var mappedValue = products.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto)
        {
            var values = updateProjectDto.Adapt<Project>();
            var validationResult = await _validator.ValidateAsync(values);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Project Failed");
        }
    }
}
