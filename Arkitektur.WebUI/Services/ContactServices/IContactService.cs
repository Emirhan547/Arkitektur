using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.ContactServices
{
    public interface IContactService:IGenericService<ResultContactDto,CreateContactDto,UpdateContactDto>
    {
       
    }
}
