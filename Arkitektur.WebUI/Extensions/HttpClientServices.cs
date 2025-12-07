using Arkitektur.WebUI.Options;
using Arkitektur.WebUI.Services.AboutServices;
using Arkitektur.WebUI.Services.AppointmentServices;
using Arkitektur.WebUI.Services.BannerServices;
using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ChooseServices;
using Arkitektur.WebUI.Services.ContactServices;
using Arkitektur.WebUI.Services.FeatureServices;
using Arkitektur.WebUI.Services.FileServices;
using Arkitektur.WebUI.Services.ProjectServices;

namespace Arkitektur.WebUI.Extensions
{
    public static class HttpClientServices
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiOptions= configuration.GetSection(nameof(ApiOptions)).Get<ApiOptions>();

            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IProjectService, ProjectService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IFileService, FileService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IAboutService, AboutService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IBannerService, BannerService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IAppointmentService, AppointmentService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IChooseService, ChooseService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IContactService, ContactService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
            services.AddHttpClient<IFeatureService, FeatureService>(client =>
            {
                client.BaseAddress = new Uri(apiOptions.BaseUrl);
            });
        }
    }
}
