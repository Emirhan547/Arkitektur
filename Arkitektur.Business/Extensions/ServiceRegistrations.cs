using Arkitektur.Business.Services.AboutServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServiceExt(this IServiceCollection services)
        {
             services.AddScoped<IAboutService, AboutService>();
            return services;
        }
    }
}
