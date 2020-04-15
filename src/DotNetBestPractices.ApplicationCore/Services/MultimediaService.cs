using DotNetBestPractices.ApplicationCore.Exceptions;
using DotNetBestPractices.Infraestructure;
using DotNetBestPractices.Infraestructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBestPractices.ApplicationCore.Services
{
    public class MultimediaService : IMultimediaService
    {
        private readonly ILogger<MultimediaServiceLogCategory> Logger;
        private readonly MultimediaServiceOptions MultimediaServiceOptions;

        public MultimediaService(ILogger<MultimediaServiceLogCategory> logger, IOptionsSnapshot<MultimediaServiceOptions> options)
        {
            Logger = logger;
            MultimediaServiceOptions = options.Value;
        }


        Task<FileStream> IMultimediaService.GetImageAsync(string fileName)
        {
            
            if(!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), MultimediaServiceOptions.MultimediaPath, fileName)))
            {
                throw new ImageNotFoundException();
            }
            
            FileStream mImage = File.Open(Path.Combine(Directory.GetCurrentDirectory(), MultimediaServiceOptions.MultimediaPath, fileName), FileMode.Open, FileAccess.Read, FileShare.Read);

            Logger.LogInformation("MultimediaService GetImageAsync");
            return Task.FromResult(mImage);
        }

    }
}
