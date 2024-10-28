using Microsoft.AspNetCore.Identity;
using PeakFit.Infrastructure.Data.Models;
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
