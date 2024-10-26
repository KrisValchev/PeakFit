using PeakFit.Infrastructure.Common;

namespace PeakFit.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();    
            return services;
        }
    }
}
