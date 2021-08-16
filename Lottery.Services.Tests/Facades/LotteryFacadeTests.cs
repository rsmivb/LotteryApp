using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services.Tests.Facades
{
    [TestClass]
    public class LotteryFacadeTests
    {
        private readonly Mock<ILogger<ILotteryFacade>> _logger;
        private readonly Mock<ILotteryDataBuilder> _lotteryDataBuilder;
        private readonly Mock<IProcessLotteryFileService> _processLotteryFileService;
        private readonly Mock<IHtmlHandlerService> _htmlHandlerService;
        private readonly Mock<ILotteryService> _lotteryService;
        private readonly LotteryFacade _facade;

        public LotteryFacadeTests()
        {
            _logger = new Mock<ILogger<ILotteryFacade>>();
            _lotteryDataBuilder = new Mock<ILotteryDataBuilder>();
            _processLotteryFileService = new Mock<IProcessLotteryFileService>();
            _htmlHandlerService = new Mock<IHtmlHandlerService>();
            _lotteryService = new Mock<ILotteryService>();
            _facade = new LotteryFacade(_logger.Object, _lotteryDataBuilder.Object, _processLotteryFileService.Object, _htmlHandlerService.Object, _lotteryService.Object);
        }
        [TestMethod("Given LotteryName load data of")]
        [TestCategory("LotteryFacade")]
        public void GivenLotteryName_LoadDataOf_Test()
        {
            var lotteryName = "MegaSena";
            var lotteryData = new LotteryData
            {

            };
            var entries = new List<List<string>>();

            _lotteryDataBuilder.Setup(m => m.Build(lotteryName)).Returns(lotteryData);
            _processLotteryFileService.Setup(m => m.Execute(lotteryData)).Returns(true);
            _htmlHandlerService.Setup(m => m.ConvertHtmlTo(lotteryData)).Returns(entries);
            _lotteryService.Setup(m => m.Load(entries, lotteryData));

            _facade.LoadData(lotteryName);
        }

    }
}
