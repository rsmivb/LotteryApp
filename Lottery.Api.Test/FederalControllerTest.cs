using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lottery.Api.Test
{
    public class FederalControllerTest
    {
        private FederalController federalControllerTest;
        private readonly Mock<IRepository<Federal>> mockRepo;
        private readonly Mock<IProcessLotteryService> mockwebService;
        private readonly Mock<ILogger<FederalController>> mockLog;
        private readonly Mock<ILotteryService> mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public FederalControllerTest()
        {

            mockwebService = new Mock<IProcessLotteryService>();
            mockLog = new Mock<ILogger<FederalController>>();
            mockLotteryService = new Mock<ILotteryService>();
            mockRepo = new Mock<IRepository<Federal>>();
            listOfLottery = new List<Federal>
            {
                new Federal
                {
                     LotteryId = 00001,
                    DateRealized = new DateTime(1962, 09, 15),
                    Dozens = new List<int> { 05349, 38031, 26492, 25151, 01416 }.OrderBy(c => c).ToList(),
                    Prize1 = 200000.00m,
                    Prize2 = 8000.00m,
                    Prize3 = 5000.00m,
                    Prize4 = 4000.00m,
                    Prize5 = 2000.00m
                }
            };
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.DownloadResultsFromSource();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("Federal")).Throws<EntryPointNotFoundException>();
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.DownloadResultsFromSource();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void GetDozenByQuantity_Test()
        {
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.GetDozenByQuantity();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.GetDozenByQuantity();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void GetResults_Test()
        {
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.GetResults();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("FederalControllerTest", "Controller Test - Federal Lottery")]
        public void GetResults_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            federalControllerTest = new FederalController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = federalControllerTest.GetResults();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
