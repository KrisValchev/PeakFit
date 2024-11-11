using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeakFit.Core.Contracts;
using PeakFit.Core.Services;
using PeakFit.Infrastructure.Common;
using PeakFit.Infrastructure.Data.Models;
using PeakFit.Web.Data;

namespace PeakFit.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        { 
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITrainerService, TrainerService>();
            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;    
                options.User.RequireUniqueEmail = true;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
