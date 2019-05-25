using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using LotteryApi.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lottery.Api.Test
{
    public class DuplaSenaControllerTest
    {
        private DuplaSenaController duplaSenaControllerTest;
        private readonly Mock<IRepository<DuplaSena>> mockRepo;
        private readonly Mock<IProcessLotteryService> mockwebService;
        private readonly Mock<ILogger<DuplaSenaController>> mockLog;
        private readonly Mock<ILotteryService> mockLotteryService;
        private readonly IEnumerable<MongoModel> listOfLottery;

        public DuplaSenaControllerTest()
        {

            mockwebService = new Mock<IProcessLotteryService>();
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
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void DownloadResultsFromSource_Test()
        {
            mockLotteryService.SetReturnsDefault(listOfLottery);
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsType<OkObjectResult>(result.Result);
            CreateServer _server = new CreateServer();
        }
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void DownloadResultsFromSource_ThrowsException_Test()
        {
            mockLotteryService.Setup(s => s.Load("DuplaSena")).Throws<EntryPointNotFoundException>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.DownloadResultsFromSource();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void GetDozenByQuantity_Test()
        {
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetDozenByQuantity();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void GetDozenByQuantity_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetDozenByQuantity();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void GetResults_Test()
        {
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetResults();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        [Trait("DuplaSenaControllerTest", "Controller Test - DuplaSena Lottery")]
        public void GetResults_ThrowsException_Test()
        {
            mockRepo.Setup(m => m.GetAll()).Throws<Exception>();
            duplaSenaControllerTest = new DuplaSenaController(mockwebService.Object, mockRepo.Object, mockLog.Object, mockLotteryService.Object);

            var result = duplaSenaControllerTest.GetResults();

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
