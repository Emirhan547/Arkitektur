using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.TeamServices
{
    public class TeamService(HttpClient _client,IFileService _fileService) : ITeamService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamDto teamDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(teamDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            teamDto.ImageUrl = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("Teams", teamDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                await _fileService.DeleteFileAsync(imageResponse.Data.ImageUrl);
                throw new ApiValidationException(result.Errors);
            }


            return result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var teams = await _client.GetFromJsonAsync<BaseResult<ResultTeamDto>>("Teams/" + id);
            await _fileService.DeleteFileAsync(teams.Data.ImageUrl);
            var response = await _client.DeleteAsync("Teams/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultTeamDto>>>("Teams");
        }

        public async Task<BaseResult<UpdateTeamDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateTeamDto>>($"Teams/{id}");
        }

        public Task<BaseResult<List<ResultTeamDto>>> GetProjectsWithCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetTeamsWithSocialsAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultTeamDto>>>("Teams/WithSocials");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamDto teamsDto)
        {
            if (teamsDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(teamsDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(teamsDto.ImageUrl);
                teamsDto.ImageUrl = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("Teams", teamsDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
            return result;

        }
    }
}
