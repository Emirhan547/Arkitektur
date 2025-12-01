using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResult<object>> CreateUserAsync(CreateUserDto userDto);
        Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto loginDto);
    }
}
