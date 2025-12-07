using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ChooseDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.ChooseServices
{
    public class ChooseService(HttpClient _client) : IChooseService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto chooseDto)
        {
            var response = await _client.PostAsJsonAsync("chooses", chooseDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync("chooses/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultChooseDto>>>("chooses");
        }

        public async Task<BaseResult<UpdateChooseDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateChooseDto>>("chooses/" + id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto chooseDto)
        {
            var response = await _client.PutAsJsonAsync("chooses", chooseDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
    }
}
