using Amazon.Runtime;
using Amazon.S3;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using Arkitektur.Business.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Arkitektur.Business.Extensions;

public static class ServiceRegistrations
{

    public static IServiceCollection AddServicesExt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(opt => opt
            .FromAssemblyOf<BusinessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        var awsOptions = configuration.GetAWSOptions();

        awsOptions.Region = Amazon.RegionEndpoint.EUNorth1;
        awsOptions.Credentials = new BasicAWSCredentials(
            configuration["AWS:AccessKey"],
            configuration["AWS:SecretKey"]
        );


        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonS3>();

        var tokenOptions = configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>();

        services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key)),
                ClockSkew = TimeSpan.Zero,



            };
        });




        return services;
    }


}