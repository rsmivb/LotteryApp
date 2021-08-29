using Lottery.Models.Lotteries;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lottery.Services.Tests
{
    [TestClass]
    public class HTMLHandlerServiceTests
    {
        private readonly Mock<ILogger<HtmlHandlerService>> _mockLogger;
        private readonly HtmlHandlerService _service;

        public HTMLHandlerServiceTests()
        {
            _mockLogger = new Mock<ILogger<HtmlHandlerService>>();
            _service = new HtmlHandlerService(_mockLogger.Object);
        }

        [TestMethod("Load Html file")]
        [TestCategory("HTMLHandlerService")]
        public void LoadHTMLFile_Test()
        {
            // Arrange
            var lotteryData = new LotteryData
            {
                Columns = 26,
                HtmlFilePath = $"{string.Concat(Environment.CurrentDirectory, @"/Resources/MEGASENA_Test.htm")}"
            };

            var expectedListString = new List<List<string>>
            {
                new List<string>
                {
                    "1","01/03/2008","71","51","63","57","24","80","31","PALMAS/TO","0,00","0","&nbsp","6","328","6032","60403","13122","0,00","59.909,90","730,61","6,00","2,00","2,00","479.279,20","1.000.000,00"
                },
                new List<string>
                {
                    "2","08/03/2008","77","18","31","25","20","63","50","SÃO PAULO/SP","0,00","0","&nbsp","10","316","5882","58525","104390","0,00","28.097,91","592,79","6,00","2,00","2,00","853.917,98","1.200.000,00"
                }
            };

            // Act
            var result = _service.ConvertHtmlTo(lotteryData);
            // Assert
            CollectionAssert.Equals(expectedListString, result);
        }

        [TestMethod("Load Html file and throws an Exception")]
        [TestCategory("HTMLHandlerService")]
        public void LoadHTMLFile_ThrowsException_Test()
        {
            // Arrange
            var lotteryData = new LotteryData
            {
                Columns = 26,
                HtmlFilePath = $"{string.Concat(Environment.CurrentDirectory, @"\Resources\html_file_doesnt_exist.htm")}"
            };

            // Assert
            Assert.ThrowsException<FileNotFoundException>(() => _service.ConvertHtmlTo(lotteryData));
        }
    }
}
