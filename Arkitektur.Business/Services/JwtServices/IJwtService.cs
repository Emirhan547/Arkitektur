using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.JwtServices
{
    public interface IJwtService
    {
        Task<TokenResponseDto> GenerateTokenAsync(AppUser user);    
    }
}
