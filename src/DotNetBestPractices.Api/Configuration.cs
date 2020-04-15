using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Hellang.Middleware.ProblemDetails;

namespace DotNetBestPractices.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureService(IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
        {
            ApplicationCore.Configuration.ConfigureService(services);

            return services
                .AddCustomMvc()
                .AddProblemDetails()
                .AddCustomOptions(config);
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app,
                                                    Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            return configureHost(app)
                .UseProblemDetails()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
