using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using LotteryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Lottery.Api.Test
{
    [TestClass]
    public class MegaSenaControllerTest
    {
        private MegaSenaController megaSenaControllerTest;

        [TestInitialize]
        public void Setup()
        {
            var appSettings = new AppSettings();
            var mockWebService = new Mock<IWebService>();
            var mockRepo = new Mock<IRepository<MegaSena>>();
            var mockwebService = new Mock<IWebService>();
            var mockLog = new Mock<ILogger<MegaSenaController>>();
            megaSenaControllerTest = new MegaSenaController(appSettings, mockwebService.Object, mockRepo.Object, mockLog.Object);
        }
        [TestMethod]
        [TestCategory("Controller Test - MegaSena Lottery")]
        public void TestMethod1()
        {
            var expectedResult = "An error was found.";
            var result = megaSenaControllerTest.DownloadResultsFromSource();


        }
    }
}
