using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;

namespace Arkitektur.Business.Services.CategoryServices;

public interface ICategoryService
{
    Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
    Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();
    Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id);
    Task<BaseResult<object>> CreateAsync(CreateCategoryDto CategoryDto);
    Task<BaseResult<object>> DeleteAsync(int id);
    Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto CategoryDto);
}