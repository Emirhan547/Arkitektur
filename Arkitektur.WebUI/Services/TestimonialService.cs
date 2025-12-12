using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TestimonialDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services
{
    public class TestimonialService(HttpClient _client,IFileService _fileService) : ITestimonialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTestimonialDto testimonialDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(testimonialDto.File);
            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }
            testimonialDto.ImageUrl = imageResponse.Data.ImageUrl;
            var response = await _client.PostAsJsonAsync("testimonials", testimonialDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                await _fileService.DeleteFileAsync(imageResponse.Data.ImageUrl);
                throw new ApiValidationException(result.Errors);
            }


            return result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var project = await _client.GetFromJsonAsync<BaseResult<ResultTestimonialDto>>("testimonials/" + id);
            await _fileService.DeleteFileAsync(project.Data.ImageUrl);
            var response = await _client.DeleteAsync("testimonials/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultTestimonialDto>>>("testimonials");
        }

        public async Task<BaseResult<UpdateTestimonialDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateTestimonialDto>>($"testimonials/{id}");
        }


        public async Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto testimonialDto)
        {
            if (testimonialDto.File is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(testimonialDto.File);
                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }
                await _fileService.DeleteFileAsync(testimonialDto.ImageUrl);
                testimonialDto.ImageUrl = imageResponse.Data.ImageUrl;
            }
            var response = await _client.PutAsJsonAsync("testimonials", testimonialDto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
            return result;

        }
    }
}
