using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public interface IAppointmentService:IGenericService<ResultAppointmentDto,CreateAppointmentDto,UpdateAppointmentDto>
    {
        Task<BaseResult<object>> ApproveAppointmentAsync(UpdateAppointmentDto appointmentDto);
        Task<BaseResult<object>> CancelAppointmentAsync(UpdateAppointmentDto appointmentDto);
    }
}
