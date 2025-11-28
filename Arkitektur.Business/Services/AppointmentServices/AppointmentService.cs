using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;

using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IGenericRepository<Appointment>_repository,IUnitOfWork _unitOfWork,IValidator<Appointment>_validator) : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDto)
        {
            var appointment= appointmentDto.Adapt<Appointment>();
            var validationResult= await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            { 
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(appointment);
            var result= await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("Create Failded)");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment =await _repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult <object>.Fail("Appointment not found");
            }
            _repository.Delete(appointment);

            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            var appointments =await _repository.GetAllAsync();
            var appointmentDtos = appointments.Adapt<List<ResultAppointmentDto>>();
            return BaseResult<List<ResultAppointmentDto>>.Success(appointmentDtos);
        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<ResultAppointmentDto>.Fail("Appointment not found");
            }
            var appointmentDto = appointment.Adapt<ResultAppointmentDto>();
            return BaseResult<ResultAppointmentDto>.Success(appointmentDto);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDtos)
        {
            var appointment = appointmentDtos.Adapt<Appointment>();
            var validationResult = await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(appointment);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
