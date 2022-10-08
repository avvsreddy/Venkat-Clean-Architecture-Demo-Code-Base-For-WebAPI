/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */


using Example.Data.Repositories;
using Example.Domain.Manager;
using Example.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TG.CandidateProfiling.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>();
                
        }

        public static void ConfigureManager(this IServiceCollection services)
        {
            services.AddScoped<IExampleManager, ExampleManager>();
        }

        public static void AddMiddleware(this IServiceCollection services)
        {
            // services.AddMvc().AddNewtonsoftJson(options =>
            // {
            //     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // });
        }

        public static void AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );
        }
        
        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();            
            services.AddResponseCaching();
        }
        
        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}