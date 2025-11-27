using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<BaseResult<List<ResultProjectDto>>> GetAllAsync();
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories();
        Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto);
        Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
