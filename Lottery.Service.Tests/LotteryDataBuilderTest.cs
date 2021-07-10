using Lottery.Models;
using Lottery.Models.Lotteries;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lottery.Service.Tests
{
    [TestClass]
    public class LotteryDataBuilderTest
    {
        private readonly Mock<ILogger<ILotteryDataBuilder>> logger;
        private readonly AppSettings appSettings;
        private LotteryDataBuilder _builder;

        public LotteryDataBuilderTest()
        {
            logger = new Mock<ILogger<ILotteryDataBuilder>>();
            appSettings = new AppSettings {
                DefaultURL = "http://some.url.com",
                TempFilePath = "/some/root/path",
                Lotteries = new List<LotterySetting>
                {
                    new LotterySetting
                    {
                        Columns = 1,
                        Name = "Lottery",
                        HtmlFileName = "/path/to/file",
                        ZipFileName = "/zip/filename"
                    }
                }
            };
        }


        [TestMethod("Build a Lottery Data Object")]
        [TestCategory("LotteryDataBuilder")]
        public void CreateFileFromStream_Test()
        {
            var lotteryName = "Lottery";
            var expectedLotteryData = new LotteryData
            {
                Columns = 1,
                Name = "Lottery",
                SenderUrlPath = new Uri("http://some.url.com/zip/filename"),
                HtmlFilePath = Path.Combine(Environment.CurrentDirectory, $"{appSettings.TempFilePath}/path/to/file"),
                ZipPath = Path.Combine(Environment.CurrentDirectory, $"{appSettings.TempFilePath}/zip/filename")
            };

            _builder = new LotteryDataBuilder(logger.Object, appSettings);

            var objectBuilt = _builder.Build(lotteryName);

            Assert.AreEqual(expectedLotteryData, objectBuilt);
        }

        [TestMethod("Try to build lotteryData object its throws an EntryPointNotFoundException")]
        [TestCategory("LotteryDataBuilder")]
        public void CreateFileFromStream_ThrowsException_Test()
        {
            var lotteryName = "WrongLotteryName";

            _builder = new LotteryDataBuilder(logger.Object, appSettings);

            Assert.ThrowsException<EntryPointNotFoundException>(() => _builder.Build(lotteryName));

        }
    }
}
