using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class WebServiceServiceTest
    {
        private readonly Mock<ILogger<IWebServiceService>> _mockLogger;
        private readonly WebServiceService _webServiceService;
        public WebServiceServiceTest()
        {
            _mockLogger = new Mock<ILogger<IWebServiceService>>();
            _webServiceService = new WebServiceService(_mockLogger.Object);
        }

        [TestMethod("Get stream based on http end point")]
        [TestCategory("WebServiceService")]
        public void GetStreamFileFromWebService_Test()
        {
            var lotteryNameTest = new Uri("http://127.0.0.1");
            var result = _webServiceService.GetStreamFileFromWebService(lotteryNameTest);
            Assert.IsTrue(result.CanRead);
        }

        [TestMethod("Get stream file and it throws a NotSupportedException")]
        [TestCategory("WebServiceService")]
        public void GetStreamFileFromWebService_ThrowsNotSupportedException_Test()
        {
            var invalidUrl = new Uri("htp://invalid.url");
            Assert.ThrowsException<NotSupportedException>(() => _webServiceService.GetStreamFileFromWebService(invalidUrl));
        }
    }
}
