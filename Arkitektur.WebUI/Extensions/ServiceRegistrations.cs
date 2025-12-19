
using Arkitektur.WebUI.Handlers;
using Arkitektur.WebUI.Options;
using Arkitektur.WebUI.Services.TokenServices;

namespace Arkitektur.WebUI.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceRegistrationsExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<ApiOptions>(configuration.GetSection(nameof(ApiOptions)));
            services.Configure<OpenAiOptions>(configuration.GetSection("OpenAI"));
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<TokenHandler>();
        }
    }
}
