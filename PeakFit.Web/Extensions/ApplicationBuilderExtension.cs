using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
using static PeakFit.Core.Constants.RoleConstants;
namespace PeakFit.Web.Extensions
{
	public static class ApplicationBuilderExtension
	{
		public static async Task AddRolesAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false && await roleManager.RoleExistsAsync(TrainerRole)==false && await roleManager.RoleExistsAsync(UserRole) == false)
			{
				var adminRole = new IdentityRole(AdminRole);
				var trainerRole = new IdentityRole(TrainerRole);
				var userRole = new IdentityRole(TrainerRole);
				await roleManager.CreateAsync(adminRole);
				await roleManager.CreateAsync(trainerRole);
				await roleManager.CreateAsync(userRole);

				//var admin = await userManager.FindByEmailAsync("admin@gmail.com");

				//if (admin != null)
				//{
				//	await userManager.AddToRoleAsync(admin, adminRole.Name);
				//}
			}

		}
	}
}
