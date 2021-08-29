using Lottery.Models;
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
    public class LotteryDataBuilderTests
    {
        private readonly Mock<ILogger<ILotteryDataBuilder>> logger;
        private readonly AppSettings appSettings;
        private LotteryDataBuilder _builder;

        public LotteryDataBuilderTests()
        {
            logger = new Mock<ILogger<ILotteryDataBuilder>>();
            appSettings = new AppSettings {
                TempFilePath = "/some/root/path",
                Lotteries = new List<LotterySetting>
                {
                    new LotterySetting
                    {
                        Columns = 1,
                        Name = "Lottery",
                        HtmlFileName = "/path/to/file",
                        WebSite ="http://some.url.com/zip/filename"
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
                Name = lotteryName,
                CaixaLotteryURL = "http://some.url.com/zip/filename",
                HtmlFilePath = $"{Environment.CurrentDirectory}{appSettings.TempFilePath}/path/to/file",
                Entries = new List<Repository.MongoModel>()
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
