using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetBestPractices.ApplicationCore
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureService(IServiceCollection services)
        {
            return services
                .AddMultimediaServices();
        }

    }
}
