using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.TeamSocialServices
{
    public class TeamSocialService(HttpClient _client) : ITeamSocialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto teamSocialDto)
        {
            var response = await _client.PostAsJsonAsync("teamSocials", teamSocialDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync("teamSocials/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultTeamSocialDto>>>("teamSocials");
        }
        public async Task<BaseResult<List<ResultTeamSocialDto>>> GetTeamSocialsWithNameSurnameAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultTeamSocialDto>>>("teamSocials/WithNameSurname");
        }

        public async Task<BaseResult<UpdateTeamSocialDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateTeamSocialDto>>("teamSocials/" + id);
        }


        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto teamSocialDto)
        {
            var response = await _client.PutAsJsonAsync("teamSocials", teamSocialDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
    }
}
