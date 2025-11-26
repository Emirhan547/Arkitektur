using Arkitektur.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.AppointmentDtos
{
    public record UpdateAppointmentDto(int Id, string NameSurname, string Email, string PhoneNumber, string ServiceName, DateTime AppointmentDate, string Message, AppointmentStatus Status);
   
}
