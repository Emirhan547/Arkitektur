using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.FeatureDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.FeatureServices
{
    public class FeatureService(HttpClient _client, IFileService _fileService) : IFeatureService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto featureDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(featureDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }
            featureDto.BackgroundImage = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("features", featureDto);
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
            var project = await _client.GetFromJsonAsync<BaseResult<ResultFeatureDto>>("features/" + id);
            await _fileService.DeleteFileAsync(project.Data.BackgroundImage);
            var response = await _client.DeleteAsync("features/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultFeatureDto>>>("features");
        }

        public async Task<BaseResult<UpdateFeatureDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateFeatureDto>>($"projects/{id}");
        }


        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto featureDto)
        {
            if (featureDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(featureDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(featureDto.BackgroundImage);
                featureDto.BackgroundImage = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("features", featureDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
            return result;

        }
    }
}
