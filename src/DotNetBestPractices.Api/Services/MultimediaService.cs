using DotNetBestPractices.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBestPractices.Api.Services
{
    public class MultimediaService : IMultimediaService
    {
        private readonly ILogger<MultimediaServiceLogCategory> Logger;

        public MultimediaService(ILogger<MultimediaServiceLogCategory> pLogger)
        {
            Logger = pLogger;
        }


        Task<string> IMultimediaService.GetImageAsync(string pFileName)
        {
            Logger.LogInformation("MultimediaService GetImageAsync");
            return Task.FromResult(pFileName);
        }

    }
}
