using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TokenDtos;
using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Arkitektur.WebUI.Services.UserServices;

public class UserService(HttpClient _client, IHttpContextAccessor _httpContextAccessor) : IUserService
{
    public async Task<BaseResult<List<ResultUserDto>>> GetAllUsersAsync()
    {
        return await _client.GetFromJsonAsync<BaseResult<List<ResultUserDto>>>("users");
    }

    public async Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id)
    {
        return await _client.GetFromJsonAsync<BaseResult<List<AssignRoleDto>>>("roleAssigns/" + id);
    }

    public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
    {
        var response = await _client.PostAsJsonAsync("roleAssigns", assignRoleDtos);
        return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
    }

    public async Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto model)
    {
        var response = await _client.PostAsJsonAsync("users/login", model);
        var result = await response.Content.ReadFromJsonAsync<BaseResult<TokenResponseDto>>();
        if (result.IsFailure)
        {
            throw new ApiValidationException(result.Errors);
        }

        JwtSecurityTokenHandler handler = new();
        var token = handler.ReadJwtToken(result.Data.Token);
        var claims = token.Claims.ToList();

        claims.Add(new Claim("Token", result.Data.Token));

        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = result.Data.ExpireTime,
            IsPersistent = true
        };

        await _httpContextAccessor.HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        return result;

    }
}