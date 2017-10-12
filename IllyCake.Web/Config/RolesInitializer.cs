namespace IllyCake.Web.Config
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal static class RolesInitializer
    {
        internal static void InitializeRoles(IServiceProvider serviceProvider, IEnumerable<string> roleNames)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in roleNames)
            {
                Task<bool> roleExists = roleManager.RoleExistsAsync(role);
                roleExists.Wait();

                if (!roleExists.Result)
                {
                    Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(role));
                    roleResult.Wait();
                }
            }
        }
    }
}
