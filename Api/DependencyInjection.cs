using Api.Exeptions.Handler;

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

            return services;
        }

         public static WebApplication UseApiServices(this WebApplication app) 
        {
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
