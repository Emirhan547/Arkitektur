using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.JwtServices;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.UserServices
{
    public class UserService(UserManager<AppUser>userManager,IJwtService _jwtService) : IUserService
    {
        public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto userDto)
        {
           var user=userDto.Adapt<AppUser>();
            var result= await userManager.CreateAsync(user,userDto.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }
            return BaseResult<object>.Success(new { Message="User Create"});
        }

        public async Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var user= await userManager.FindByEmailAsync(loginDto.Email);
            if (user==null)
            {
                return BaseResult<TokenResponseDto>.Fail("User Not Found");
            }
            var result= await userManager.CheckPasswordAsync(user,loginDto.Password);
            if (!result)
            {
                return BaseResult<TokenResponseDto>.Fail("Email or Password Wrong");
            }
            var tokenResponse=await _jwtService.GenerateTokenAsync(user);
            return BaseResult<TokenResponseDto>.Success(tokenResponse);

        }
    }
}

