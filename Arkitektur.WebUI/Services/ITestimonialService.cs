using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TestimonialDtos;

namespace Arkitektur.WebUI.Services
{
    public interface ITestimonialService
    {
        Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync();
        Task<BaseResult<UpdateTestimonialDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTestimonialDto testimonialDto);
        Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto testimonialDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
