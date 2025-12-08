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

            services.AddScoped<TokenHandler>();
            services.AddScoped<ITokenService,TokenService>();
        }
    }
}
