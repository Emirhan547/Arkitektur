using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.ChooseDtos
{
    public record UpdateChooseDto(int Id,string Title, string Description, string Icon);
}
