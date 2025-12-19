using Arkitektur.API.Extensions;
using Arkitektur.API.Options;
using Arkitektur.Business.Extensions;
using Arkitektur.DataAccess.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesExt(builder.Configuration)
                .AddServicesExt(builder.Configuration);
builder.Services.Configure<AdminUserOptions>(builder.Configuration.GetSection("AdminUser"));
builder.Services.AddControllers(opt =>
{
    var adminPolicy = new AuthorizationPolicyBuilder().RequireRole("Admin").Build();
    var managerPolicy = new AuthorizationPolicyBuilder().RequireRole("Manager").Build();

    opt.Filters.Add(new AuthorizeFilter(adminPolicy));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
await app.SeedIdentityDataAsync();
app.Run();
