using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.Options;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Arkitektur.Business.Services.JwtServices
{
    public class JwtService(IOptions<JwtTokenOptions>tokenOptions,UserManager<AppUser>_userManager) : IJwtService
    {
        private readonly JwtTokenOptions _tokenOptions = tokenOptions.Value;
        public async Task<TokenResponseDto> GenerateTokenAsync(AppUser user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));
            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
        new Claim("fullName", string.Join(" ", user.FirstName, user.LastName)),
        new Claim(JwtRegisteredClaimNames.Email, user.Email)
    };

            // ROLLERİ EKLİYOR MU KONTROL ET
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // BU ÇOK ÖNEMLİ
                Console.WriteLine($"[JwtService] Adding role to token: {role}"); // LOG EKLE
            }

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            var responseDto = new TokenResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpireTime = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes)
            };

            return responseDto;
        }
    }
}
