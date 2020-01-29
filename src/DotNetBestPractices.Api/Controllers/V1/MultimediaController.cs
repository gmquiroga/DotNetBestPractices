using DotNetBestPractices.Api.Services;
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
    [Route("api/multimedia")]
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
        [Route("GetImage")]
        public async Task<IActionResult> GetImage(/*string pFileName*/)
        {
            Logger.LogInformation("MultimediaController GetImage");
            Logger.LogInformation("MultimediaPath: {0}", this.MultimediaServiceOptions.MultimediaPath);
            string mResult = await MultimediaService.GetImageAsync("GetImegeFromService");
            return Ok(mResult);
        }
    }
}
