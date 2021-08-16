using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Lottery.Services.Tests
{
    [TestClass]
    public class WebServiceServiceTests
    {
        private readonly Mock<ILogger<ICaixaWSService>> _mockLogger;

        public WebServiceServiceTests()
        {
            _mockLogger = new Mock<ILogger<ICaixaWSService>>();
        }

        [TestMethod("Get content based on http end point")]
        [TestCategory("WebServiceService")]
        public void GetStreamFileFromWebService_Test()
        {
            var expected = "content";
            var lotteryNameTest = "http://127.0.0.1";
            var fakeResponse = new FakeHttpMessageHandler(new List<HttpResponseMessage> { new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(expected) } });
            var fakeHttpClient = new HttpClient(fakeResponse);
            var _caixaWSService = new CaixaWSService(_mockLogger.Object, fakeHttpClient);
            var result = _caixaWSService.GetContent(lotteryNameTest);
            Assert.AreEqual(expected, result);
        }

        [TestMethod("Get content file and it throws a NotSupportedException")]
        [TestCategory("WebServiceService")]
        public void GetStreamFileFromWebService_ThrowsNotSupportedException_Test()
        {
            var invalidUrl = "htp://invalid.url";
            var fakeHttpClient = new HttpClient();
            var _caixaWSService = new CaixaWSService(_mockLogger.Object, fakeHttpClient);
            Assert.ThrowsException<ArgumentException>(() => _caixaWSService.GetContent(invalidUrl));
        }
    }
}
