using DotNetBestPractices.Api.Services;
using DotNetBestPractices.Infraestructure.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtensions
    {

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            return services
                .AddMvcCore().Services;
        }
        
        public static IServiceCollection AddMultimediaServices(this IServiceCollection services)
        {
            return services.AddSingleton<IMultimediaService, MultimediaService>();
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration pConfiguration)
        {
            return services.Configure<MultimediaServiceOptions>(pConfiguration.GetSection(nameof(MultimediaServiceOptions)));
        }
    }
}
