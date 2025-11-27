using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();
        Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
