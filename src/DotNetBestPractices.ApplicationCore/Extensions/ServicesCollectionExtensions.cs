using DotNetBestPractices.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddMultimediaServices(this IServiceCollection services)
        {
            //return services.AddSingleton<IMultimediaService, MultimediaService>();
            return services.AddScoped<IMultimediaService, MultimediaService>();
        }
    }
}
