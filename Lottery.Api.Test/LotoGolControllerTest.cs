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
    public class LotoGolControllerTest
    {
        private LotoGolController lotoGolControllerTest;
        private Mock<IRepository<LotoGol>> mockRepo;
        private Mock<IWebService> mockwebService;
        private Mock<ILogger<LotoGolController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        [TestInitialize]
        public void Setup()
        {

            mockwebService = new Mock<IWebService>();
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
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("LotoGol")).Throws<EntryPointNotFoundException>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.DownloadResultsFromSource();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void GetDozenByQuantity_Test()
        {
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetDozenByQuantity();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void GetAllLoteries_Test()
        {
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        [TestCategory("Controller Test - LotoGol Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotoGolControllerTest = new LotoGolController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotoGolControllerTest.GetAllLoteries();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
