using Lottery.Models;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class ProcessLotteryTest
    {
        private AppSettings _appSettings;
        private Mock<ILogger<IProcessLotteryService>> _mockLogger;

        [TestInitialize]
        public void Setup()
        {
            _appSettings = new AppSettings { TempFilePath = @"\TestPath", Lotteries = new List<LotterySetting> { new LotterySetting { Name = "TestLottery", WebService = "http://www.dummy.com", ZipFileName = "test.zip" } } };
            _mockLogger = new Mock<ILogger<IProcessLotteryService>>();
        }
        [TestCategory("Process Lottery Service Test")]
        [TestMethod]
        public void DownloadFile_LotteryNameWrong_ThrowsArgumentNullException_Test()
        {
            var testLotteryName = "WrongLotteryName";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var mockWebService = new Mock<IWebServiceService>();
            var _webService = new ProcessLotteryService(mockFileHandler.Object, _appSettings, mockWebService.Object, _mockLogger.Object);
            Assert.ThrowsException<ArgumentNullException>(() => _webService.ProcessLotteryFile(testLotteryName));
        }
        [TestCategory("Process Lottery Service Test")]
        [TestMethod]
        public void DownloadFile_Test()
        {
            var testLotteryName = "TestLottery";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var mockWebService = new Mock<IWebServiceService>();
            var _webService = new ProcessLotteryService(mockFileHandler.Object, _appSettings, mockWebService.Object, _mockLogger.Object);
            var returnedValue = _webService.ProcessLotteryFile(testLotteryName);
            Assert.IsTrue(returnedValue);
        }

        [TestCategory("Process Lottery Service Test")]
        [TestMethod]
        public void DownloadFile_InvalidLotteryName_ThrowsArgumentNullException_Test()
        {
            var testLotteryName = "WrongLotteryName";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var mockWebService = new Mock<IWebServiceService>();
            var _webService = new ProcessLotteryService(mockFileHandler.Object, _appSettings, mockWebService.Object, _mockLogger.Object);
            Assert.ThrowsException<ArgumentNullException>(() => _webService.ProcessLotteryFile(testLotteryName));
        }
    }
}
