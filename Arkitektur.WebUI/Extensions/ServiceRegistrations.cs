using Arkitektur.WebUI.Options;

namespace Arkitektur.WebUI.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceRegistrationsExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<ApiOptions>(configuration.GetSection(nameof(ApiOptions)));
        }
    }
}
