using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync();
        Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDtos);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDtos);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> ApproveAppointmentAsync(UpdateAppointmentDto appointmentDto);
        Task<BaseResult<object>> CancelAppointmentAsync(UpdateAppointmentDto appointmentDto);
    }
}
