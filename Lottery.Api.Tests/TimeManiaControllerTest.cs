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
    public class TimeManiaControllerTest
    {
        private readonly TimeManiaController timeManiaControllerTest;
        private readonly IRepository<TimeMania> mockRepo;
        private readonly ILogger<TimeManiaController> mockLog;
        private readonly ILotteryService mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public TimeManiaControllerTest()
        {

            mockLog = Substitute.For<ILogger<TimeManiaController>>();
            mockLotteryService = Substitute.For<ILotteryService>();
            mockRepo = Substitute.For<IRepository<TimeMania>>();
            listOfLottery = new List<TimeMania>
            {
                new TimeMania
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2008, 03, 01),
                    Dozens = new List<int> { 71,51,63,57,24,80,31 }.OrderBy(c => c).ToList(),
                    Team = "PALMAS/TO",
                    TotalValue = 0.00m,
                    TotalWinners7 = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    TotalWinners6 = 6,
                    TotalWinners5 = 328,
                    TotalWinners4 = 6032,
                    TotalWinners3 = 60403,
                    WinnersTeam = 13122,
                    TotalValueNumbers7 =0.00m ,
                    TotalValueNumbers6 = 59909.90m,
                    TotalValueNumbers5 = 730.61m,
                    TotalValueNumbers4 = 6.00m,
                    TotalValueNumbers3 = 2.00m,
                    TeamValue = 2.00m,
                    AccumulatedValue = 479279.20m,
                    EstimatedPrize = 1000000.00m
                }
            };
        }
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void DownloadResultsFromSource_Test()
        //{
        //    mockLotteryService.SetReturnsDefault(listOfLottery);
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void DownloadResultsFromSource_ThrowsException_Test()
        //{
        //    mockLotteryService.Setup(s => s.Load("TimeMania")).Throws<EntryPointNotFoundException>();
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.DownloadResultsFromSource();
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void GetDozenByQuantity_Test()
        //{
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void GetDozenByQuantity_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void GetAllLoteries_Test()
        //{
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.GetResults();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("TimeManiaControllerTest", "Controller Test - TimeMania Lottery")]
        //public void GetAllLoteries_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = timeManiaControllerTest.GetResults();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
    }
}
