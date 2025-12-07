using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.BannerDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.BannerServices
{
    public class BannerService(HttpClient _client,IFileService _fileService) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto bannerDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(bannerDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            bannerDto.ImageUrl = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("banners", bannerDto);
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
             var bannerResult=await GetByIdAsync(id);
            await _fileService.DeleteFileAsync(bannerResult.Data.ImageUrl);
            var response = await _client.DeleteAsync("banners/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultBannerDto>>>("banners");
        }

        public async Task<BaseResult<UpdateBannerDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateBannerDto>>("banners/" + id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto bannerDto)
        {
            if (bannerDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(bannerDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(bannerDto.ImageUrl);
                bannerDto.ImageUrl = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("banners", bannerDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
             }
            return result;

        }
    }
}
