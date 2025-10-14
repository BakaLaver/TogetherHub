using Api.Security.Services;
using Domain.Security;
using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            string secretKey = config["AuthSettings:SecretKey"]!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });


            services.AddAuthorization();
            services.AddScoped<IJwtSecurityService, JwtSecurityService>();
            return services;
        }
    }
}
