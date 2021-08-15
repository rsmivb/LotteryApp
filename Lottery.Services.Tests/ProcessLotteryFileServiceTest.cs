using Lottery.Models.Lotteries;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class ProcessLotteryFileServiceTest
    {
        private readonly Mock<ILogger<IProcessLotteryFileService>> _logger;
        private readonly Mock<IFileHandlerService> _fileHandlerService;
        private readonly Mock<IWebServiceService> _webService;
        private readonly IProcessLotteryFileService _service;

        public ProcessLotteryFileServiceTest()
        {
            _logger = new Mock<ILogger<IProcessLotteryFileService>>();
            _fileHandlerService = new Mock<IFileHandlerService>();
            _webService = new Mock<IWebServiceService>();
            _service = new ProcessLotteryFileService(_logger.Object, _fileHandlerService.Object,_webService.Object);
        }

        [TestMethod("Process file to a lottery")]
        [TestCategory("ProcessLotteryFileService")]
        public void DownloadFile_Test()
        {
            var lotteryData = new LotteryData
            {
                SenderUrlPath = new Uri("http://some.url.com"),
                ZipPath = "some/path/"
            };

            _webService.Setup(r => r.GetStreamFileFromWebService(lotteryData.SenderUrlPath)).Returns(new MemoryStream());
            _fileHandlerService.Setup(r => r.ProcessToFile(null,lotteryData.ZipPath,lotteryData.HtmlFilePath));

            Assert.IsTrue(_service.Execute(lotteryData));
        }

        [TestMethod("Process file to a lottery throws an ArgumentNullException")]
        [TestCategory("ProcessLotteryFileService")]
        public void DownloadFile_InvalidLotteryName_ThrowsArgumentNullException_Test()
        {
            var lotteryData = new LotteryData
            {
                SenderUrlPath = new Uri("http://some.url.com"),
                ZipPath = "some/path/"
            };

            _webService.Setup(r => r.GetStreamFileFromWebService(lotteryData.SenderUrlPath)).Throws(new Exception());

            Assert.IsFalse(_service.Execute(lotteryData));
        }
    }
}
