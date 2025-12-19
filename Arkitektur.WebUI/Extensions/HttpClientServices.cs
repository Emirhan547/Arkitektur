using Arkitektur.WebUI.Handlers;
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
using Arkitektur.WebUI.Services.TeamServices;
using Arkitektur.WebUI.Services.TeamSocialServices;
using Arkitektur.WebUI.Services.TestimonialServices;
using Arkitektur.WebUI.Services.UserServices;

namespace Arkitektur.WebUI.Extensions;

public static class HttpClientServices
{

    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {

        var apiOptions = configuration.GetSection(nameof(ApiOptions)).Get<ApiOptions>();

        services.AddHttpClient<ICategoryService, CategoryService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IProjectService, ProjectService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IAboutService, AboutService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IBannerService, BannerService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IAppointmentService, AppointmentService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IChooseService, ChooseService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IContactService, ContactService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IFeatureService, FeatureService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IUserService, UserService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<ITeamService, TeamService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);

        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<IFileService, FileService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);
        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<ITeamSocialService, TeamSocialService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);
        }).AddHttpMessageHandler<TokenHandler>();

        services.AddHttpClient<ITestimonialService, TestimonialService>(options =>
        {
            options.BaseAddress = new Uri(apiOptions.BaseUrl);
        }).AddHttpMessageHandler<TokenHandler>();
    }


}