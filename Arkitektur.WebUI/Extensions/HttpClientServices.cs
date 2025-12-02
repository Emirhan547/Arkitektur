using Arkitektur.WebUI.Services.CategoryServices;

namespace Arkitektur.WebUI.Extensions
{
    public static class HttpClientServices
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7100/api/");
            });
        }
    }
}
