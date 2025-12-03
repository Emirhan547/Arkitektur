using Arkitektur.WebUI.DTOs.ProjectDtos;

namespace Arkitektur.WebUI.DTOs.CategoryDtos
{
    public record ResultCategoriesWithProjectsDto(int Id, string CategoryName, IList<ProjectDto> Projects);
}
