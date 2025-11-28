using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.ContactService
{
    public interface IContactService
    {
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<ResultContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateContactDto createContactDto);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateContactDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
