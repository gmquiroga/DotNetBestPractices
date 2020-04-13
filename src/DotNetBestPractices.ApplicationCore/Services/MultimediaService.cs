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

        public MultimediaService(ILogger<MultimediaServiceLogCategory> pLogger, IOptionsSnapshot<MultimediaServiceOptions> pOptions)
        {
            Logger = pLogger;
            MultimediaServiceOptions = pOptions.Value;
        }


        Task<FileStream> IMultimediaService.GetImageAsync(string pFileName)
        {
            if(!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), MultimediaServiceOptions.MultimediaPath, pFileName)))
            {
                throw new FileNotFoundException();
            }
            FileStream mImage = File.Open(Path.Combine(Directory.GetCurrentDirectory(), MultimediaServiceOptions.MultimediaPath, pFileName), FileMode.Open, FileAccess.Read, FileShare.Read);

            Logger.LogInformation("MultimediaService GetImageAsync");
            return Task.FromResult(mImage);
        }

    }
}
