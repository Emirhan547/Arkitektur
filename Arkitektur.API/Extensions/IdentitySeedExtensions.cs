
using Arkitektur.API.Options;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Arkitektur.API.Extensions;

public static class IdentitySeedExtensions
{
    public static async Task SeedIdentityDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var adminUserOptions = serviceProvider.GetRequiredService<IOptions<AdminUserOptions>>().Value;

        string[] roles = ["Admin", "Manager", "User"];

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
            }
        }

        if (string.IsNullOrWhiteSpace(adminUserOptions.Email) || string.IsNullOrWhiteSpace(adminUserOptions.Password))
        {
            return;
        }

        var adminUser = await userManager.FindByEmailAsync(adminUserOptions.Email);

        if (adminUser is null)
        {
            adminUser = new AppUser
            {
                Email = adminUserOptions.Email,
                UserName = adminUserOptions.UserName ?? adminUserOptions.Email,
                FirstName = adminUserOptions.FirstName ?? "Admin",
                LastName = adminUserOptions.LastName ?? "User",
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(adminUser, adminUserOptions.Password);

            if (!createResult.Succeeded)
            {
                return;
            }
        }

        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}