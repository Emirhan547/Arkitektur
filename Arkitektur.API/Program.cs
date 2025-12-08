using Arkitektur.Business.Extensions;
using Arkitektur.DataAccess.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRepositoriesExt(builder.Configuration)
    .AddServiceExt(builder.Configuration);
builder.Services.AddControllers(opt=>
{
    var adminPolicy= new AuthorizationPolicyBuilder().RequireRole("Admin").Build();
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

app.Run();
