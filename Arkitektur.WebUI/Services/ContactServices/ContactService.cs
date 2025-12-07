using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.ContactServices
{
    public class ContactService(HttpClient _client) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto contactDto)
        {
            var response = await _client.PostAsJsonAsync("contacts", contactDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync("contacts/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultContactDto>>>("contacts");
        }

        public async Task<BaseResult<UpdateContactDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateContactDto>>("contacts/" + id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto contactDto)
        {
            var response = await _client.PutAsJsonAsync("contacts", contactDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
    }
}
