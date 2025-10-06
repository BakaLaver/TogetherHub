using Api.Exeptions.Handler;
using Application.Topics.Queries.GetTopics;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(
              this IServiceCollection services, IConfiguration configuration)

        {
            services.AddExceptionHandler<CustomExeptionHandler>();
            services.AddControllers();
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

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
