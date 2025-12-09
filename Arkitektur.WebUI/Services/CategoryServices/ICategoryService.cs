using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;

namespace Arkitektur.WebUI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();
        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCategoryDto categoryDto);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto categoryDto);
        Task<BaseResult<object>> DeleteAsync(int id);

    }
}
