using Lottery.Models.Lotteries;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace Lottery.Services.Tests
{
    [TestClass]
    public class ProcessLotteryFileServiceTests
    {
        private readonly Mock<ILogger<IProcessLotteryFileService>> _logger;
        private readonly Mock<IFileHandlerService> _fileHandlerService;
        private readonly Mock<ICaixaWSService> _webService;
        private readonly IProcessLotteryFileService _service;

        public ProcessLotteryFileServiceTests()
        {
            _logger = new Mock<ILogger<IProcessLotteryFileService>>();
            _fileHandlerService = new Mock<IFileHandlerService>();
            _webService = new Mock<ICaixaWSService>();
            _service = new ProcessLotteryFileService(_logger.Object, _fileHandlerService.Object,_webService.Object);
        }

        [TestMethod("Process file to a lottery")]
        [TestCategory("ProcessLotteryFileService")]
        public void DownloadFile_Test()
        {
            var lotteryData = new LotteryData
            {
                CaixaLotteryURL = "http://some.url.com",
                HtmlFilePath = "/some/path/"
            };

            _webService.Setup(r => r.GetContent(lotteryData.CaixaLotteryURL)).Returns(string.Empty);
            _fileHandlerService.Setup(r => r.ProcessToFile(null,lotteryData.HtmlFilePath));

            Assert.IsTrue(_service.Execute(lotteryData));
        }

        [TestMethod("Process file to a lottery throws an ArgumentNullException")]
        [TestCategory("ProcessLotteryFileService")]
        public void DownloadFile_InvalidLotteryName_ThrowsArgumentNullException_Test()
        {
            var lotteryData = new LotteryData
            {
                CaixaLotteryURL = "http://some.url.com"
            };

            _webService.Setup(r => r.GetContent(lotteryData.CaixaLotteryURL)).Throws(new Exception());

            Assert.IsFalse(_service.Execute(lotteryData));
        }
    }
}
