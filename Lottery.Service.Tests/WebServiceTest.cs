using Lottery.Models;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class WebServiceTest
    {
        private AppSettings _appSettings;
        private Mock<ILogger<IWebService>> _mockLogger;

        [TestInitialize]
        public void Setup()
        {
            _appSettings = new AppSettings { TempFilePath = @"\TestPath", Lotteries = new List<LotterySetting> { new LotterySetting { Name = "TestLottery", WebService = "http://www.dummy.com", ZipFileName = "test.zip" } } };
            _mockLogger = new Mock<ILogger<IWebService>>();
        }
        [TestCategory("Web Service Test")]
        [TestMethod]
        public void GetStreamFileFromWebService_Test()
        {
            var lotteryNameTest = "http://www.d.u.m.m.y.com";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var _webService = new WebService(mockFileHandler.Object, _appSettings, _mockLogger.Object);

            var result = _webService.GetStreamFileFromWebService(lotteryNameTest);
            Assert.IsTrue(result.CanRead);
        }
        [TestCategory("Web Service Test")]
        [TestMethod]
        public void DownloadFile_Test()
        {
            var testLotteryName = "TestLottery";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var _webService = new WebService(mockFileHandler.Object, _appSettings, _mockLogger.Object);
            var returnedValue = _webService.DownloadFile(testLotteryName);
            Assert.IsTrue(returnedValue);
        }
        [TestCategory("Web Service Test")]
        [TestMethod]
        public void DownloadFile_LotteryNameWrong_ThrowsArgumentNullException_Test()
        {
            var testLotteryName = "WrongLotteryName";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var _webService = new WebService(mockFileHandler.Object, _appSettings, _mockLogger.Object);
            Assert.ThrowsException<ArgumentNullException>(() => _webService.DownloadFile(testLotteryName));
        }
        [TestCategory("Web Service Test")]
        [TestMethod]
        public void DownloadFile_InvalidLotteryName_ThrowsArgumentNullException_Test()
        {
            var testLotteryName = "WrongLotteryName";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var _webService = new WebService(mockFileHandler.Object, _appSettings, _mockLogger.Object);
            Assert.ThrowsException<ArgumentNullException>(() => _webService.DownloadFile(testLotteryName));
        }
        [TestCategory("Web Service Test")]
        [TestMethod]
        public void DownloadFile_AppSettingsInvalidUrl_ThrowsNotSupportedException_Test()
        {
            var testLotteryName = "TestLottery";
            var invalidAppSetting = new AppSettings { TempFilePath = @"\TestPath", Lotteries = new List<LotterySetting> { new LotterySetting { Name = "TestLottery", WebService = "htp://invalid.url", ZipFileName = "test.zip" } } };
            var mockFileHandler = new Mock<IFileHandlerService>();
            var _webService = new WebService(mockFileHandler.Object, invalidAppSetting, _mockLogger.Object);
            Assert.ThrowsException<NotSupportedException>(() => _webService.DownloadFile(testLotteryName));
        }
    }
}
