using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.UserServices
{
    public class UserService(UserManager<AppUser>userManager) : IUserService
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
    }
}

