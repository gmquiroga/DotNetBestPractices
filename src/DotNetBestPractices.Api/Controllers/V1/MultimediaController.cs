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
        

        public MultimediaController(IMultimediaService multimediaService, IOptionsSnapshot<MultimediaServiceOptions> options, ILogger<MultimediaServiceLogCategory> logger)
        {
            
            this.MultimediaService = multimediaService;
            this.Logger = logger;
            this.MultimediaServiceOptions = options.Value;
            
        }

        [HttpGet]
        [Route("GetImage/{pFileName}")]
        public async Task<IActionResult> GetImage(string fileName)
        {
            System.IO.FileStream mResult;
            Logger.LogInformation("Obteniendo imagen: {0}", fileName);
            Logger.LogInformation("MultimediaPath: {0}", this.MultimediaServiceOptions.MultimediaPath);
            
            mResult = await MultimediaService.GetImageAsync(fileName);
            
            return Ok(mResult);
        }
    }
}
