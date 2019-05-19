using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Api.Test
{
    public class LotoGolControllerTest
    {
        private LotoGolController lotoGolControllerTest;
        private Mock<IRepository<LotoGol>> mockRepo;
        private Mock<IProcessLotteryService> mockwebService;
        private Mock<ILogger<LotoGolController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        public LotoGolControllerTest()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<LotoGolController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<LotoGol>>();
            listOfLottery = new List<LotoGol>
            {
                new LotoGol
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2002, 02, 18),
                    City = "",
                    UF = "",
                    Winners5 = 0,
                    Average5 = 0.00m,
                    IsAcumlated5 = true,
                    Acumulated5 = 425061.45m,
                    Winners4 = 3,
                    Average4 = 3278.78m,
                    IsAcumlated4 = false,
                    Acumulated4 = 0.00m,
                    Winners3 = 481,
                    Average3 = 20.38m,
                    IsAcumlated3 = false,
                    Acumulated3 = 0.00m,
                    Dozens = new List<char> { '2','+','3','0','2','1','1','+','+','0' }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    EstimatedPrize = 0.00m
                }
            };
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.DownloadResultsFromSource();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("LotoGol")).Throws<EntryPointNotFoundException>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.DownloadResultsFromSource();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void GetDozenByQuantity_Test()
        {
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetDozenByQuantity();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetDozenByQuantity();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void GetAllLoteries_Test()
        {
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetResults();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotoGolControllerTest","Controller Test - LotoGol Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetResults();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
