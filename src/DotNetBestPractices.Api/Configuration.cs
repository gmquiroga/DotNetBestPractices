using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DotNetBestPractices.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureService(IServiceCollection services, IConfiguration config)
        {
            return services
                .AddCustomMvc()
                .AddMultimediaServices()
                .AddCustomOptions(config);
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app,
                                                    Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            return configureHost(app)
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
