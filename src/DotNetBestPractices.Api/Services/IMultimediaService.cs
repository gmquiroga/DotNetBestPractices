using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBestPractices.Api.Services
{
    public interface IMultimediaService
    {
        Task<string> GetImageAsync(string pFileName);

    }
}
