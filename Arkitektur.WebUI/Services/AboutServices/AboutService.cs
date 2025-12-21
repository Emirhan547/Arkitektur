using System.CodeDom;
using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.AboutServices;

public class AboutService(HttpClient _client, IFileService _fileService) : IAboutService
{
    public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
    {
        return await _client.GetFromJsonAsync<BaseResult<List<ResultAboutDto>>>("Abouts");
    }

    public async Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id)
    {
        return await _client.GetFromJsonAsync<BaseResult<UpdateAboutDto>>("Abouts/" + id);
    }

    public async Task<BaseResult<object>> CreateAsync(CreateAboutDto aboutDto)
    {
        var imageResponse = await _fileService.UploadFileAsync(aboutDto.File);
        if (imageResponse.IsFailure)
        {
            throw new ApiValidationException(imageResponse.Errors);
        }
        aboutDto.ImageUrl = imageResponse.Data.ImageUrl;
        var response = await _client.PostAsJsonAsync("Abouts", aboutDto);
        var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto aboutDto)
    {
        if (aboutDto.File is not null)
        {
            await _fileService.DeleteFileAsync(aboutDto.ImageUrl);
            var imageResponse = await _fileService.UploadFileAsync(aboutDto.File);
            aboutDto.ImageUrl = imageResponse.Data.ImageUrl;
        }
        var response = await _client.PutAsJsonAsync("Abouts", aboutDto);
        var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var about = await _client.GetFromJsonAsync<BaseResult<ResultAboutDto>>("Abouts/" + id);
        await _fileService.DeleteFileAsync(about.Data.ImageUrl);
        var response = await _client.DeleteAsync("Abouts/" + id);
        return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
    }


}