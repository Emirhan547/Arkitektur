using Arkitektur.DataAccess.Interceptors;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Extensions
{
    public static class RepositoryRegistrations
    {
        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options=>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                options.AddInterceptors(new AuditDbContextInterceptor());
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));  
            return services;
        }
    }
}
