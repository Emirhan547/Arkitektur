using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public class ProjectService(HttpClient _client,IFileService _fileService) : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto projectDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(projectDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            projectDto.ImageUrl = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("projects", projectDto);
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
            var project=await _client.GetFromJsonAsync<BaseResult<ResultProjectDto>>("projects/"+id);
            await _fileService.DeleteFileAsync(project.Data.ImageUrl);
            var response =await  _client.DeleteAsync("projects/"+id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultProjectDto>>>("projects");
        }

        public async Task<BaseResult<UpdateProjectDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateProjectDto>>($"projects/{id}");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoriesAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultProjectDto>>>("projects/WithCategories");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto projectDto)
        {
            if (projectDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(projectDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(projectDto.ImageUrl);
                projectDto.ImageUrl = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("projects", projectDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
            return result;

        }
    }
}
