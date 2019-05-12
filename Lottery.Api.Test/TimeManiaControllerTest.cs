using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Api.Test
{
    [TestClass]
    public class TimeManiaControllerTest
    {
        private TimeManiaController timeManiaControllerTest;
        private Mock<IRepository<TimeMania>> mockRepo;
        private Mock<IProcessLotteryService> mockwebService;
        private Mock<ILogger<TimeManiaController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<TimeManiaController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<TimeMania>>();
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
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("TimeMania")).Throws<EntryPointNotFoundException>();
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void GetDozenByQuantity_Test()
        {
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void GetAllLoteries_Test()
        {
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - TimeMania Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            timeManiaControllerTest = new TimeManiaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = timeManiaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
