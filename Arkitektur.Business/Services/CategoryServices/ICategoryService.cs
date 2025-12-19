using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.Services.IGenericServices;

namespace Arkitektur.Business.Services.CategoryServices;

public interface ICategoryService:IGenericService<ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto>
{
    Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();

}