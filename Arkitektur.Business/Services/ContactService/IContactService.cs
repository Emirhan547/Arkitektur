using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ContactService
{
    public interface IContactService:IGenericService<ResultContactDto,CreateContactDto,UpdateContactDto>
    {

    }
}
