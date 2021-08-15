using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lottery.Api.Test
{
    public class LotoManiaControllerTest
    {
        private LotoManiaController lotoManiaControllerTest;
        private readonly IRepository<LotoMania> mockRepo;
        private readonly ILogger<LotoManiaController> mockLog;
        private readonly ILotteryService mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public LotoManiaControllerTest()
        {

            mockLog = Substitute.For<ILogger<LotoManiaController>>();
            mockLotteryService = Substitute.For<ILotteryService>();
            mockRepo = Substitute.For<IRepository<LotoMania>>();
            listOfLottery = new List<LotoMania>
            {
                new LotoMania
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(1999, 10, 02),
                    Dozens = new List<int> { 16,11,88,32,25,00,70,78,73,61,90,89,46,95,06,33,34,21,14,22}.OrderBy(c => c).ToList(),
                    TotalValue = 0.00m,
                    TotalWinners20 = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    TotalWinners19 = 1,
                    TotalWinners18 = 46,
                    TotalWinners17 = 446,
                    TotalWinners16 = 2716,
                    TotalWinnersNoNumbers = 0,
                    TotalValueNumbers20 = 0.00m,
                    TotalValueNumbers19 = 118746.87m,
                    TotalValueNumbers18 = 2581.46m,
                    TotalValueNumbers17 = 132.62m,
                    TotalValueNumbers16 = 21.78m,
                    TotalValueNoNumbers = 0.00m,
                    Acumulated20 = 178120.31m,
                    Acumulated19 = 0.00m,
                    Acumulated18 = 0.00m,
                    Acumulated17 = 0.00m,
                    Acumulated16 = 0.00m,
                    AcumulatedNoNumbers = 59373.46m,
                    PrizeEstimated = 0.00m,
                    SpecialPrizeEstimated = 0m
                }
            };
        }
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void DownloadResultsFromSource_Test()
        //{
        //    mockLotteryService.SetReturnsDefault(listOfLottery);
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void DownloadResultsFromSource_ThrowsException_Test()
        //{
        //    mockLotteryService.Setup(s => s.Load("LotoMania")).Throws<EntryPointNotFoundException>();
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void GetDozenByQuantity_Test()
        //{
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void GetDozenByQuantity_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void GetAllLoteries_Test()
        //{
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.GetResults();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("LotoManiaControllerTest", "Controller Test - LotoMania Lottery")]
        //public void GetAllLoteries_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    lotoManiaControllerTest = new LotoManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = lotoManiaControllerTest.GetResults();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
    }
}
