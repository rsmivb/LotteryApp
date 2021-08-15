using Lottery.Api.Controllers;
using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Api.Tests
{
    public class LotoGolControllerTest
    {
        private readonly LotoGolController lotoGolControllerTest;
        private readonly IRepository<LotoGol> mockRepo;
        private readonly ILogger<LotoGolController> mockLog;
        private readonly ILotteryService mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public LotoGolControllerTest()
        {

            mockLog = Substitute.For<ILogger<LotoGolController>>();
            mockLotteryService = Substitute.For<ILotteryService>();
            mockRepo = Substitute.For<IRepository<LotoGol>>();
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
                    Dozens = new List<string> { "2", "+", "3", "0", "2", "1", "1", "+", "+", "0" }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    EstimatedPrize = 0.00m
                }
            };
        }
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void DownloadResultsFromSource_Test()
        //{
        //    mockLotteryService.SetReturnsDefault(listOfLottery);
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void DownloadResultsFromSource_ThrowsException_Test()
        //{
        //    mockLotteryService.Setup(s => s.Load("LotoGol")).Throws<EntryPointNotFoundException>();
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void GetDozenByQuantity_Test()
        //{
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void GetDozenByQuantity_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void GetAllLoteries_Test()
        //{
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.GetResults();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoGolControllerTest", "Controller Test - LotoGol Lottery")]
        //public void GetAllLoteries_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoGolControllerTest.GetResults();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
    }
}
