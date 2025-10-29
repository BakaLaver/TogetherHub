using Api.Security.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationsServicesService(
              this IServiceCollection services, IConfiguration configuration)

        {
            services.AddScoped<IJwtSecurityService, JwtSecurityService>();
            return services;
        }
    }
}
            //services.AddScoped<ITopicsService, TopicsService>();
