using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.AboutServices
{
    public class AboutService(HttpClient _client,IFileService _fileService) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto aboutDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(aboutDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }
            aboutDto.ImageUrl = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("abouts", aboutDto);
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
            var project = await _client.GetFromJsonAsync<BaseResult<ResultAboutDto>>("abouts/" + id);
            await _fileService.DeleteFileAsync(project.Data.ImageUrl);
            var response = await _client.DeleteAsync("features/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultAboutDto>>>("abouts");
        }

        public async Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateAboutDto>>($"abouts/{id}");
        }


        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto aboutDto)
        {
            if (aboutDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(aboutDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(aboutDto.ImageUrl);
                aboutDto.ImageUrl = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("features", aboutDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
            return result;

        }
    }
}
