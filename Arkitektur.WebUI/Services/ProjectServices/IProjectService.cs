using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<BaseResult<List<ResultProjectDto>>> GetAllAsync();
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoriesAsync();
        Task<BaseResult<UpdateProjectDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateProjectDto projectDto);
        Task<BaseResult<object>> UpdateAsync(UpdateProjectDto projectDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
