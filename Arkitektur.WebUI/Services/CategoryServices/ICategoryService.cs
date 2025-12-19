using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.CategoryServices
{
    public interface ICategoryService:IGenericService<ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto>
    {
        Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();

    }
}
