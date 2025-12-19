using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TestimonialDtos;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.Repositories.TestimonialServices;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.TestimonialServices
{
    public class TestimonialService(ITestimonialRepository _repository, IUnitOfWork _unitOfWork, IValidator<Testimonial> _validator) : ITestimonialService
    {
        
            public async Task<BaseResult<object>> CreateAsync(CreateTestimonialDto createTestimonialDto)
            {
                var Testimonial = createTestimonialDto.Adapt<Testimonial>();
                var validationResult = await _validator.ValidateAsync(Testimonial);
                if (!validationResult.IsValid)
                {
                    return BaseResult<object>.Fail(validationResult.Errors);
                }
                await _repository.CreateAsync(Testimonial);
                var result = await _unitOfWork.SaveChangesAsync();
                return result ? BaseResult<object>.Success(Testimonial) : BaseResult<object>.Fail("Create Failed");
            }

            public async Task<BaseResult<object>> DeleteAsync(int id)
            {
                var Testimonial = await _repository.GetByIdAsync(id);
                if (Testimonial is null)
                {
                    return BaseResult<object>.Fail("Testimonial Not Found");
                }
            _repository.Delete(Testimonial);
                var result = await _unitOfWork.SaveChangesAsync();
                return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");

            }

            public async Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync()
            {
                var Testimonials = await _repository.GetAllAsync();
                var mappedValue = Testimonials.Adapt<List<ResultTestimonialDto>>();
                return BaseResult<List<ResultTestimonialDto>>.Success(mappedValue);
            }

            public async Task<BaseResult<ResultTestimonialDto>> GetByIdAsync(int id)
            {
                var Testimonial = await _repository.GetByIdAsync(id);
                if (Testimonial is null)
                {
                    return BaseResult<ResultTestimonialDto>.Fail("Testimonial Not Found");
                }
                var mappedValue = Testimonial.Adapt<ResultTestimonialDto>();
                return BaseResult<ResultTestimonialDto>.Success(mappedValue);
            }

            public async Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto testimonialDto)
            {
                var Testimonial = testimonialDto.Adapt<Testimonial>();
                var validationResult = await _validator.ValidateAsync(Testimonial);
                if (!validationResult.IsValid)
                {
                    return BaseResult<object>.Fail(validationResult.Errors);
                }
            _repository.Update(Testimonial);
                var result = await _unitOfWork.SaveChangesAsync();
                return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
            }
        }
}
