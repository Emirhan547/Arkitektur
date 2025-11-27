using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.ProjectDtos
{
    public record ResultProjectDto(int Id,
        string ImageUrl, string Title,string Description,string Item1,string Item2,string Item3,int CategoryId,ResultCategoryDto Category);
    
}
