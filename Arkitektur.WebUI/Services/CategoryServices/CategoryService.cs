using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.CategoryServices
{
    public class CategoryService(HttpClient _client) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto categoryDto)
        {
            var response = await _client.PostAsJsonAsync("categories", categoryDto);
            var result= await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors):result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response =  await _client.DeleteAsync("categories/"+id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCategoryDto>>>("categories");
        }

        public async Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateCategoryDto>>("categories/"+id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var response = await _client.PutAsJsonAsync("categories", categoryDto);
             var result= await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
    }
}
