using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.DataAccess.Repositories.BannerRepositories;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;


namespace Arkitektur.Business.Services.BannerServices
{
    public class BannerService (IBannerRepository _repository,IUnitOfWork _unitOfWork,IValidator<Banner>_validator): IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto)
        {
            var banner=createBannerDto.Adapt<Banner>();
            var validationResult=await _validator.ValidateAsync(banner);
            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(banner);
            var result=await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(banner) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var banner= await _repository.GetByIdAsync(id);
            if(banner==null)
            {
                return BaseResult<object>.Fail("Banner Not Found");
            }
            _repository.Delete(banner);
            var result=await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            var banners= await _repository.GetAllAsync();
            var resultBanners=banners.Adapt<List<ResultBannerDto>>();
            return BaseResult<List<ResultBannerDto>>.Success(resultBanners);
        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner == null)
            {
                return BaseResult<ResultBannerDto>.Fail("Banner Not Found");
            }
            var resultBanner = banner.Adapt<ResultBannerDto>();
            return BaseResult<ResultBannerDto>.Success(resultBanner);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var banner = updateBannerDto.Adapt<Banner>();
            var validationResult = await _validator.ValidateAsync(banner);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
