using Api.Security.Services;
using Domain.Security;
using Infrastructure.Data.DataBaseContext;

namespace Api.Security.Extensions
{
    public static class IdentityOptionExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddIdentityCore<CustomIdentityUser>(opition =>
            {
                opition.Password.RequireDigit = false;
                opition.Password.RequiredLength = 1;
                opition.Password.RequireLowercase = false;
                opition.Password.RequireUppercase = false;
                opition.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization();
            services.AddScoped<IJwtSecurityService, JwtSecurityService>();
            return services;
        }
    }
}
