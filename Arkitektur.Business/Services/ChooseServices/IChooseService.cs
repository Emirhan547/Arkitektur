
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ChooseServices
{
    public interface IChooseService:IGenericService<ResultChooseDto,CreateChooseDto,UpdateChooseDto>
    {
    }
}
