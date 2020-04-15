﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBestPractices.ApplicationCore.Services
{
    public interface IMultimediaService
    {
        Task<FileStream> GetImageAsync(string fileName);

    }
}
