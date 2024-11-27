using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeakFit.Infrastructure.Data;
using PeakFit.Web.Data;
using PeakFit.Web.Extensions;
using static PeakFit.Web.Extensions.ServiceCollectionExtension;

namespace PeakFit.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllersWithViews();

            builder.Services.AddApplicationServices();
            builder.Logging.AddConsole();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
            }
            else
            {
				app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
				app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            //Adding roles
            app.AddTrainerRoleAsync().Wait();
            app.AddAdminRoleAsync().Wait();
            app.AddUserRoleAsync().Wait();
            app.Run();
        }
    }
}
