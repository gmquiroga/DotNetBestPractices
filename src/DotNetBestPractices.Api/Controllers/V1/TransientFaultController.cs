using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetBestPractices.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TransientFaultController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var value = new Random().Next(2);

            if (value % 2 == 0)
            {
                return Ok("Pong!");
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

}
