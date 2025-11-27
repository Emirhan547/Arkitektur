using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.ProjectDtos
{
    public record ProjectDto (int Id,
        string ImageUrl, string Title,string Description,string Item1,string Item2,string Item3,int CategoryId);

}
