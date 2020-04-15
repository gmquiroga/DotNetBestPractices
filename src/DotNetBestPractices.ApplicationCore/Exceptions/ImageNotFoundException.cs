using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetBestPractices.ApplicationCore.Exceptions
{
    public class ImageNotFoundException: Exception
    {
        public ImageNotFoundException()
        {
        }

        public ImageNotFoundException(string message)
            : base(message)
        {
        }

        public ImageNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
