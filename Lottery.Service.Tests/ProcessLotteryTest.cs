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
        private readonly AppSettings _appSettings;
        private readonly Mock<ILogger<IProcessLotteryService>> _mockLogger;

        public ProcessLotteryTest()
        {
            _appSettings = new AppSettings { TempFilePath = @"\TestPath", DefaultURL= "http://www.dummy.com", Lotteries = new List<LotterySetting> { new LotterySetting { Name = "TestLottery", WebFileName = "lottery.zip" } } };
            _mockLogger = new Mock<ILogger<IProcessLotteryService>>();
        }

        [TestMethod("Process file to a lottery")]
        [TestCategory("ProcessLotteryService")]
        public void DownloadFile_Test()
        {
            var testLotteryName = "TestLottery";
            var mockFileHandler = new Mock<IFileHandlerService>();
            var mockWebService = new Mock<IWebServiceService>();
            var _webService = new ProcessLotteryService(mockFileHandler.Object, _appSettings, mockWebService.Object, _mockLogger.Object);
            var returnedValue = _webService.ProcessLotteryFile(testLotteryName);
            Assert.IsTrue(returnedValue);
        }

        [TestMethod("Process file to a lottery throws an ArgumentNullException")]
        [TestCategory("ProcessLotteryService")]
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
