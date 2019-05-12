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
    public class LotoFacilControllerTest
    {
        private LotoFacilController lotoFacilControllerTest;
        private Mock<IRepository<LotoFacil>> mockRepo;
        private Mock<IProcessLotteryService> mockwebService;
        private Mock<ILogger<LotoFacilController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<LotoFacilController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<LotoFacil>>();
            listOfLottery = new List<LotoFacil>
            {
                new LotoFacil
                {
                    LotteryId = 1,
                DateRealized = new DateTime(2003, 09, 29),
                Dozens = new List<int> { 18,20,25,23,10,11,24,14,06,02,13,09,05,16,03 }.OrderBy(c => c).ToList(),
                TotalAmount = 0.00m,
                Winners15 = 5,
                City = string.Empty,
                UF = "BA",
                Winners14 = 154,
                Winners13 = 4645,
                Winners12 = 48807,
                Winners11 = 257593,
                AverageAmount15 = 49765.82m,
                AverageAmount14 = 689.84m,
                AverageAmount13 = 10.00m,
                AverageAmount12 = 4.00m,
                AverageAmount11 = 2.00m,
                Accumulated15 = 0.00m,
                EstimatedPrize = 0.00m,
                SpecialAmount = 0.00m
                }
            };
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("LotoFacil")).Throws<EntryPointNotFoundException>();
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void GetDozenByQuantity_Test()
        {
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void GetAllLoteries_Test()
        {
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoFacil Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoFacilControllerTest = new LotoFacilController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoFacilControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
