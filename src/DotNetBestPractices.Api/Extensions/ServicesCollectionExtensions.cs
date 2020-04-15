﻿using DotNetBestPractices.Infraestructure.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hellang.Middleware.ProblemDetails;
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
                .AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).Services;
        }
       
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<MultimediaServiceOptions>(configuration.GetSection(nameof(MultimediaServiceOptions)));
        }

        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services
                .AddProblemDetails(configure =>
                {
                    configure.IncludeExceptionDetails = _ => environment.EnvironmentName == "Development";
                });
        }
        
    }
}
