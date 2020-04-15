using DotNetBestPractices.ApplicationCore.Exceptions;
using DotNetBestPractices.ApplicationCore.Services;
using DotNetBestPractices.Infraestructure;
using DotNetBestPractices.Infraestructure.Options;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace UnitTests.ApplicationCore.Services
{
    public class MultimediaServicesShould
    {
        private readonly IMultimediaService MultimediaService;
        private readonly string imageInvalidName = "imageInvalidName";

        public MultimediaServicesShould()
        {
            var multimediaServiceOptions = new MultimediaServiceOptions()
            {
               MultimediaPath = "images"
            };

            Mock<IOptionsSnapshot<MultimediaServiceOptions>> mockOptionsSnapshot = new Mock<IOptionsSnapshot<MultimediaServiceOptions>>(MockBehavior.Strict);

            mockOptionsSnapshot.SetupGet(o => o.Value).Returns(multimediaServiceOptions);

            MultimediaService = new MultimediaService(new NullLogger<MultimediaServiceLogCategory>(), mockOptionsSnapshot.Object);
        }

        [Fact]
        public void ThrowsGivenInvalidImageName()
        {
            Assert.ThrowsAsync<ImageNotFoundException>(async () =>
                await MultimediaService.GetImageAsync(imageInvalidName));
        }
    }
}
