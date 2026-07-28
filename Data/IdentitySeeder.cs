using HossamSystem.Entities;
using HossamSystem.Enums;
using Microsoft.AspNetCore.Identity;

namespace HossamSystem.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { Role.Owner.ToString(), Role.EmployeeManager.ToString(), Role.EmployeeStaff.ToString(), Role.Tenant.ToString(), Role.Supplier.ToString() };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var defaults = new[]
            {
                ("owner@system.com", "Owner@123", Role.Owner.ToString()),
                ("manager@system.com", "Manager@123", Role.EmployeeManager.ToString()),
                ("staff@system.com", "Staff@123", Role.EmployeeStaff.ToString())
            };

            foreach (var (email, password, role) in defaults)
            {
                var existingUser = await userManager.FindByEmailAsync(email);
                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Seeder Error ({email}): {error.Code} - {error.Description}");
                        }
                    }
                }
            }
        }
    }
}