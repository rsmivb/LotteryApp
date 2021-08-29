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
    public class MegaSenaControllerTest
    {
        private readonly LotteryController megaSenaControllerTest;
        private readonly IRepository<MegaSena> mockRepo;
        private readonly ILogger<LotteryController> mockLog;
        private readonly ILotteryService mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public MegaSenaControllerTest()
        {

            mockLog = Substitute.For<ILogger<LotteryController>>();
            mockLotteryService = Substitute.For<ILotteryService>();
            mockRepo = Substitute.For<IRepository<MegaSena>>();
            listOfLottery = new List<MegaSena>
            {
                new MegaSena
                {
                    LotteryId = 1,
                    City = string.Empty,
                    DateRealized = new DateTime(1996, 03, 11),
                    Dozens = new List<int> { 41,05,04,52,30,33 }.OrderBy(c => c).ToList(),
                    WinnersSena = 0,
                    WinnersQuina = 17,
                    WinnersQuadra = 2016,
                    WinnersSenaValue = 0.00m,
                    WinnersQuinaValue = 39158.92m,
                    WinnersQuadraValues = 330.21m
                }
            };
        }
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void DownloadResultsFromSource_Test()
        //{
        //    mockLotteryService.SetReturnsDefault(listOfLottery);
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void DownloadResultsFromSource_ThrowsException_Test()
        //{
        //    mockLotteryService.Setup(s => s.Load("MegaSena")).Throws<EntryPointNotFoundException>();
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.DownloadResultsFromSource();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void GetDozenByQuantity_Test()
        //{
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void GetDozenByQuantity_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.GetDozenByQuantity();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void GetAllLoteries_Test()
        //{
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.GetResults();
        //
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}
        //[Fact]
        //[Trait("MegaSenaControllerTest", "Controller Test - MegaSena Lottery")]
        //public void GetAllLoteries_ThrowsException_Test()
        //{
        //    mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
        //    megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);
        //
        //    var result = megaSenaControllerTest.GetResults();
        //
        //    Assert.IsType<NotFoundObjectResult>(result.Result);
        //}
    }
}
