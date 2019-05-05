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
    public class MegaSenaControllerTest
    {
        private MegaSenaController megaSenaControllerTest;
        private Mock<IRepository<MegaSena>> mockRepo;
        private Mock<IWebService> mockwebService;
        private Mock<ILogger<MegaSenaController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IWebService>();
            mockLog = new Mock<ILogger<MegaSenaController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<MegaSena>>();
            listOfLottery = new List<MegaSena>
            {
                new MegaSena
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(1996, 03, 11),
                    Dozens = new List<int> { 41,05,04,52,30,33 }.OrderBy(c => c).ToList(),
                    TotalCollection = 0.00m,
                    Winners6Numbers = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    Average6Numbers = 0.00m,
                    Winners5Numbers = 17,
                    Average5Numbers = 39158.92m,
                    Winners4Numbers = 2016,
                    Average4Numbers = 330.21m,
                    IsAccumulated = true,
                    AccumulatedPrize = 1714650.23m,
                    EstimatedPrize = 0.00m,
                    AccumulatedMegaSenaVirada = 0.00m
                }
            };
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public async void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("MegaSena")).Throws<EntryPointNotFoundException>();
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void GetDozenByQuantity_Test()
        {
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void GetAllLoteries_Test()
        {
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            megaSenaControllerTest = new MegaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = megaSenaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
