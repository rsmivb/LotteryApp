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
    public class QuinaControllerTest
    {
        private QuinaController quinaControllerTest;
        private Mock<IRepository<Quina>> mockRepo;
        private Mock<IProcessLotteryService> mockwebService;
        private Mock<ILogger<QuinaController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<QuinaController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<Quina>>();
            listOfLottery = new List<Quina>
            {
                new Quina
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(1994, 03, 13),
                    Dozens = new List<int> { 25,45,60,76,79 }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    Winners5 = 3,
                    City = string.Empty,
                    UF = string.Empty,
                    Average5Numbers = 75731225.00m,
                    Winners4 = 127,
                    Average4Numbers = 1788927.00m,
                    Winners3 = 7030,
                    Average3Numbers = 42982.00m,
                    Winners2 = 0,
                    Average2Numbers = 0.00m,
                    IsAccumulated = false,
                    AccumulatedValue = 0.00m,
                    EstimatePrize = 0.00m,
                    AccumulatedSorteioSaoJoao = 0.00m
                }
            };
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("Quina")).Throws<EntryPointNotFoundException>();
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void GetDozenByQuantity_Test()
        {
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void GetAllLoteries_Test()
        {
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.GetResults();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - Quina Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            quinaControllerTest = new QuinaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = quinaControllerTest.GetResults();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
