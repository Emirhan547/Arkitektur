using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;

namespace Arkitektur.WebUI.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync();
        Task<BaseResult<UpdateAppointmentDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDtos);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDtos);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> ApproveAppointmentAsync(int id);
        Task<BaseResult<object>> CancelAppointmentAsync(int id);
        
    }
}
