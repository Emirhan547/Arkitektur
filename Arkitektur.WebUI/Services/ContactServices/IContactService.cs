using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ContactDtos;

namespace Arkitektur.WebUI.Services.ContactServices
{
    public interface IContactService
    {
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<UpdateContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateContactDto contactDto);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto contactDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
