using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.AppointmentServices
{
    public class AppointmentService(HttpClient _client) : IAppointmentService
    {
        public async Task<BaseResult<object>> ApproveAppointmentAsync(int id)
        {
            var response = await GetByIdAsync(id);
            var result= await _client.PatchAsJsonAsync("appointments/approve",response.Data);
            return await result.Content.ReadFromJsonAsync<BaseResult<object>>();

        }

        public async Task<BaseResult<object>> CancelAppointmentAsync(int id)
        {
            var response = await GetByIdAsync(id);
            var result = await _client.PatchAsJsonAsync("appointments/cancel", response.Data);
            return await result.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDto)
        {
            var response = await _client.PostAsJsonAsync("appointments", appointmentDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync("appointments/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultAppointmentDto>>>("appointments");
        }

        public async Task<BaseResult<UpdateAppointmentDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateAppointmentDto>>("appointments/" + id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto)
        {
            var response = await _client.PutAsJsonAsync("appointments", appointmentDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }

        }
    }

