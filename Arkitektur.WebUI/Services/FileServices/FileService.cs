using System.Net.Http.Headers;
using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.FileDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.FileServices;

public class FileService(HttpClient _client) : IFileService
{
    public async Task<BaseResult<object>> DeleteFileAsync(string imageUrl)
    {
        var response=await _client.DeleteAsync($"images?imageUrl={imageUrl}");
        return new BaseResult<object> { IsSuccessful = true, IsFailure =false };
    }

    public async Task<BaseResult<ResultFileDto>> UploadFileAsync(IFormFile file)
    {
        var form = new MultipartFormDataContent();

        if (file is null)
        {
            throw new ApiValidationException([new Error { PropertyName = "file", ErrorMessage = "Lütfen bir dosya seçin." }]);
        }



        var streamContent = new StreamContent(file.OpenReadStream());
        streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

        form.Add(streamContent, "file", file.FileName);

        var response = await _client.PostAsync("images/upload", form);
        var responseString=await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApiValidationException([new Error { PropertyName = "file", ErrorMessage = "Dosya yüklenirken bir hata oluştu" }]);
        }

        return await response.Content.ReadFromJsonAsync<BaseResult<ResultFileDto>>();


    }
}