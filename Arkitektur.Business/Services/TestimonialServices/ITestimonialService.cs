
using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TestimonialDtos;
using Arkitektur.Business.Services.IGenericServices;

namespace Arkitektur.Business.Services.TestimonialServices
{
    public interface ITestimonialService:IGenericService<ResultTestimonialDto,CreateTestimonialDto,UpdateTestimonialDto>
    {
    }
}
