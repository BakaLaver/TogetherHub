﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationsServicesService(
              this IServiceCollection services, IConfiguration configuration)

        {
            //services.AddScoped<ITopicsService, TopicsService>();

            return services;
        }
    }
}
