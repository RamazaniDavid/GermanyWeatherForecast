using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Rmz.WeatherForecast.Api.Models.ConfigModels;
using Rmz.WeatherForecast.Api.Services.ApiServices;
using Rmz.WeatherForecast.Api.Services.ApiServices.OpenWeatherMap;

namespace Rmz.WeatherForecast.Api.Common.Extends
{
    /// <summary>
    /// To config service in startup file
    /// </summary>
    public static class ServiceExtends
    {

        /// <summary>
        /// Config CORS Policies
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


        }

        /// <summary>
        /// Config Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "German Weather Information", Version = "v1" });
            });


        }

        /// <summary>
        /// Configure dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IOwmProvider, OwmProvider>();


        }

        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {services.AddOptions<ProviderApiConfigs>()
                .Bind(configuration.GetSection("ProviderApiConfigs"));
        }

    }
}
