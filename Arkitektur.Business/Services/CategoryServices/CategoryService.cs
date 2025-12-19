using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.DataAccess.Repositories.CategoryRepositories;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
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

namespace Arkitektur.Business.Services.CategoryServices
{
    public class CategoryService(ICategoryRepository _repository,IUnitOfWork _unitOfWork,IValidator<Category> _validator) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category= createCategoryDto.Adapt<Category>();
            var validationResult= await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(category);
            var result=await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(category):BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }
            _repository.Delete(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            var mappedResult = categories.Adapt<List<ResultCategoryDto>>();
            return BaseResult<List<ResultCategoryDto>>.Success(mappedResult);
        }



        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return BaseResult<ResultCategoryDto>.Fail("Category Not Found");
            }
            var resultCategory = category.Adapt<ResultCategoryDto>();
            return BaseResult<ResultCategoryDto>.Success(resultCategory);
        }

        public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync()
        {
            var categories = await _repository.GetCategoriesWithProjectsAsync();
            var resultCategories= categories.Adapt<List<ResultCategoriesWithProjectsDto>>();
            return BaseResult<List<ResultCategoriesWithProjectsDto>>.Success(resultCategories);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category= updateCategoryDto.Adapt<Category>();
            var validationResult=await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(category);
            var result=await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
