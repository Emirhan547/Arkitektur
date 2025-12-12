
using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TestimonialDtos;

namespace Arkitektur.Business.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync();
        Task<BaseResult<ResultTestimonialDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
