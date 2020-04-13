using DotNetBestPractices.ApplicationCore.Services;
using DotNetBestPractices.Infraestructure;
using DotNetBestPractices.Infraestructure.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBestPractices.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MultimediaController: ControllerBase
    {
        
        private readonly IMultimediaService MultimediaService;
        private readonly ILogger<MultimediaServiceLogCategory> Logger;
        private readonly MultimediaServiceOptions MultimediaServiceOptions;
        

        public MultimediaController(IMultimediaService pMultimediaService, IOptionsSnapshot<MultimediaServiceOptions> pOptions, ILogger<MultimediaServiceLogCategory> pLogger)
        {
            
            this.MultimediaService = pMultimediaService;
            this.Logger = pLogger;
            this.MultimediaServiceOptions = pOptions.Value;
            
        }

        [HttpGet]
        [Route("GetImage/{pFileName}")]
        public async Task<IActionResult> GetImage(string pFileName)
        {
            Logger.LogInformation("Obteniendo imagen: {0}", pFileName);
            Logger.LogInformation("MultimediaPath: {0}", this.MultimediaServiceOptions.MultimediaPath);
            var mResult = await MultimediaService.GetImageAsync(pFileName);
            return Ok(mResult);
        }
    }
}
