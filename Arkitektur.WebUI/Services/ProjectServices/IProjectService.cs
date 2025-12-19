using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public interface IProjectService:IGenericService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
    {
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoriesAsync();

    }
}
