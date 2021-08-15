using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace Lottery.Api.Tests
{

    public class StartupTest
    {
        [Fact]
        [Trait("StartupTest", "Startup Test - Init .NET core app test")]
        public void Startup_Test()
        {
            //Arrange
            var contentRootPath = GetContentRootPath();
            var config = new ConfigurationBuilder()
                        .SetBasePath(contentRootPath)
                        .AddJsonFile("appsettings.json")
                        .Build();
            var builder = new WebHostBuilder()
                   .UseContentRoot(contentRootPath)
                   .UseEnvironment("Testing")
                   .UseConfiguration(config) // load configuration
                   .UseStartup<Startup>();  // Uses Start up class from your API Host project to configure the test server

            // Create test server
            var _server = new TestServer(builder);
            // create http client
            var _testClient = _server.CreateClient();

            Assert.NotNull(_server);
            Assert.NotNull(_testClient);
            // test each dependency injection if exists
            var service = _server.Host.Services.GetService(typeof(IWebServiceService));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IFileHandlerService));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IHtmlHandlerService));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(ILotteryService));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<DuplaSena>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<MegaSena>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Loteca>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Federal>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoFacil>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoGol>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoMania>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Quina>));
            Assert.NotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<TimeMania>));
            Assert.NotNull(service);
        }
        private string GetContentRootPath()
        {
            var testProjectPath = Environment.CurrentDirectory;

            var relativePathToHostProject = @"../../../../Lottery.Api";

            return Path.Combine(testProjectPath, relativePathToHostProject);
        }
    }
}
