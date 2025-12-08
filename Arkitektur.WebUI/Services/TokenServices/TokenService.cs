using System.Security.Claims;

namespace Arkitektur.WebUI.Services.TokenServices
{
    public class TokenService(IHttpContextAccessor _httpContextAccessor) : ITokenService
    {
        public string GetUserToken => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token")?.Value;

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value;

        public string GetUserRole => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

        public string GetUserName => _httpContextAccessor.HttpContext.User.FindFirst("name")?.Value;

        public string GetUserFullName => _httpContextAccessor.HttpContext.User.FindFirst("fullName")?.Value;
    }
}
