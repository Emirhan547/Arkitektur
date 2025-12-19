using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ProjectServices
{
    public interface IProjectService:IGenericService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
    {
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories();

    }
}
