using Api.Exeptions.Handler;
using Api.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;


namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(
              this IServiceCollection services, IConfiguration configuration)

        {
            services.AddExceptionHandler<CustomExeptionHandler>();
            services.AddControllers(option =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                option.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddOpenApi();
            services.AddCors(options =>
            {
                options.AddPolicy("react-policy", policy => 
                {
                    policy.AllowAnyHeader()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:5000");
                });
            });

            services.AddMediatR(config => config
            .RegisterServicesFromAssembly(typeof(GetTopicsHandler).Assembly)
            );

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddIdentityServices(configuration);

            return services;
        }

        
         public static WebApplication UseApiServices(this WebApplication app) 
        {

            app.UseCors("react-policy");
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseExceptionHandler(options => { });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
