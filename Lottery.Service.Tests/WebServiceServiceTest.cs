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

        [TestCategory("Web Service Service Test")]
        [TestMethod]
        public void GetStreamFileFromWebService_Test()
        {
            var lotteryNameTest = "http://www.d.u.m.m.y.com";
            var result = _webServiceService.GetStreamFileFromWebService(lotteryNameTest);
            Assert.IsTrue(result.CanRead);
        }
        [TestCategory("Web Service Service Test")]
        [TestMethod]
        public void GetStreamFileFromWebService_ThrowsNotSupportedException_Test()
        {
            var invalidUrl = "htp://invalid.url";
            Assert.ThrowsException<NotSupportedException>(() => _webServiceService.GetStreamFileFromWebService(invalidUrl));
        }
    }
}
