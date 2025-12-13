using System.Net;
using System.Net.Http.Headers;
using Arkitektur.WebUI.Services.TokenServices;
using Microsoft.AspNetCore.Authentication;

namespace Arkitektur.WebUI.Handlers;

public class TokenHandler(IHttpContextAccessor _contextAccessor, ITokenService _tokenService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetUserToken);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var httpContext = _contextAccessor.HttpContext;
            if (httpContext != null)
            {
                await httpContext.SignOutAsync();
                httpContext.Response.Redirect("/Auth/Login");
            }
        }

        return response;
    }
}