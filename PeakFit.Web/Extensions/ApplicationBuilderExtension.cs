using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
using System.Data;
using static PeakFit.Core.Constants.RoleConstants;
namespace PeakFit.Web.Extensions
{
	public static class ApplicationBuilderExtension
	{
		public static async Task AddAdminRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
			{
				var adminRole = new IdentityRole(AdminRole);
				await roleManager.CreateAsync(adminRole);
                var admin = await userManager.FindByEmailAsync("admin@gmail.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, adminRole.Name);
                }
            }

		}
		public static async Task AddTrainerRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(TrainerRole) == false)
			{
			
				var trainerRole = new IdentityRole(TrainerRole);
				await roleManager.CreateAsync(trainerRole);
                var trainer = await userManager.FindByEmailAsync("trainer@gmail.com");

                if (trainer != null)
                {
                    await userManager.AddToRoleAsync(trainer, trainerRole.Name);
                }

            }

		}
		public static async Task AddUserRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(UserRole) == false)
			{
				var userRole = new IdentityRole(UserRole);
				await roleManager.CreateAsync(userRole);
                var user = await userManager.FindByEmailAsync("user@gmail.com");

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, userRole.Name);
                }
            }

		}
		//private void CreateScoupUserAndRoleManager(this IApplicationBuilder app)
		//{
		//	using var scope = app.ApplicationServices.CreateScope();
		//	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
		//	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		//}
	}
}
