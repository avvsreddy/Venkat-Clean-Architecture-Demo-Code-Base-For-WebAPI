/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */



using System;
using System.Runtime.InteropServices;
using Example.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TG.CandidateProfiling.Data;

namespace TG.CandidateProfiling.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = String.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("CandidateProfilingPostgresSQLDbWindows");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                connection = configuration.GetConnectionString("CandidateProfilingPostgresSQLDbDocker");
            }

            //services.AddDbContextPool<CandidateProfilingContext>(options => options.UseNpgsql(connection));
            services.AddDbContext<ExampleAlbumDBContext>(options => options.UseInMemoryDatabase("Test"));

            return services;
        }
    }
}