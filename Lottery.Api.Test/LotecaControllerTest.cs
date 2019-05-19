using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Api.Test
{
    public class LotecaControllerTest
    {
        private LotecaController lotecaControllerTest;
        private Mock<IRepository<Loteca>> mockRepo;
        private Mock<IProcessLotteryService> mockwebService;
        private Mock<ILogger<LotecaController>> mockLog;
        private Mock<ILotteryService> mockLotteryService;
        private IEnumerable<MongoModel> listOfLottery;

        public LotecaControllerTest()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<LotecaController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<Loteca>>();
            listOfLottery = new List<Loteca>
            {
                new Loteca
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2002,02,18),
                    Winners14 = 2,
                    City = string.Empty,
                    UF = "BA",
                    Average14 = 55985.99m,
                    IsAcumulated = false,
                    AmountValue14 = 0.00m,
                    Winners13 = 44,
                    AmountValue13 = 2544.81m,
                    Winners12 = 1028,
                    AmountValue12 = 144.68m,
                    Dozens = new List<char> { '2','1','1','2','1','2','x','1','x','1','1','2','1','1',}.OrderBy(c => c).ToList(),
                    TotalAmount = 0,
                    EstimatedPrize = 0
                }
            };
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.DownloadResultsFromSource();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("Loteca")).Throws<EntryPointNotFoundException>();
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.DownloadResultsFromSource();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void GetDozenByQuantity_Test()
        {
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.GetDozenByQuantity();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.GetDozenByQuantity();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void GetAllLoteries_Test()
        {
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.GetResults();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("LotecaControllerTest","Controller Test - Loteca Lottery")]
        public void GetAllLoteries_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            lotecaControllerTest = new LotecaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = lotecaControllerTest.GetResults();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
