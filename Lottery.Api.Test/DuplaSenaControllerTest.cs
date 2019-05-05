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
    public class DuplaSenaControllerTest
    {
        private DuplaSenaController duplaSenaControllerTest;
        private Mock<IRepository<DuplaSena>> mockRepo;
        private Mock<IWebService> mockwebService;
        private Mock<ILogger<DuplaSenaController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IWebService>();
            mockLog = new Mock<ILogger<DuplaSenaController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<DuplaSena>>();
            listOfLottery = new List<DuplaSena>
            {
                new DuplaSena
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2001, 11, 06),
                    DozensRound1 = new List<int> { 07, 15, 24, 41, 48, 50 }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    Winners6NumbersRound1 = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    Average6NumbersRound1 = 0.00m,
                    IsAccumulated = true,
                    AccumulatedValueRound1 = 588519.68m,
                    Winners5NumbersRound1 = 0,
                    Average5NumbersRound1 = 0.00m,
                    Winners4NumbersRound1 = 0,
                    Average4NumbersRound1 = 0.00m,
                    Winners3NumbersRound1 = 0,
                    Average3NumbersRound1 = 0.00m,
                    DozensRound2 = new List<int> { 09, 37, 41, 43, 44, 49 }.OrderBy(c => c).ToList(),
                    Winners6NumbersRound2 = 0,
                    Average6NumbersRound2 = 0.00m,
                    Winners5NumbersRound2 = 55,
                    Average5NumbersRound2 = 2317.59m,
                    Winners4NumbersRound2 = 1307,
                    Average4NumbersRound2 = 97.16m,
                    Winners3NumbersRound2 = 0,
                    Average3NumbersRound2 = 0.00m,
                    EstimatedPrize = 0.00m,
                    AccumulatedEspecialPascoa = 0.00m
                }
            };
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("DuplaSena")).Throws<EntryPointNotFoundException>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void GetDozenByQuantity_Test()
        {
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void GetAllLoteries_Test()
        {
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - DuplaSena Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}