using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Http;


namespace LotteryApi.Test
{
    [TestClass]
    public class StartupTest
    {
        private TestServer _server;
        private HttpClient _client;

        [TestMethod]
        [TestCategory("Startup Test - Init .NET core app test")]
        public void Startup_Test()
        {
            var contentRootPath = GetContentRootPath();
            var config = new ConfigurationBuilder()
                        .SetBasePath(contentRootPath)
                        .AddJsonFile("appsettings.json")
                        .Build();
            var builder = new WebHostBuilder()
                   .UseContentRoot(contentRootPath)
                   .UseEnvironment("Testing")
                   .UseConfiguration(config) // load configuration
                   .ConfigureTestServices(services => services.LoadDependencies()) // load dependecies
                   .UseStartup<Startup>();  // Uses Start up class from your API Host project to configure the test server


            // Create test server
            _server = new TestServer(builder);
            Assert.IsNotNull(_server);
            // create http client
            _client = _server.CreateClient();
            Assert.IsNotNull(_client);
            // test each dependency injection if exists
            var service = _server.Host.Services.GetService(typeof(IWebServiceService));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IFileHandlerService));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IProcessLotteryService));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IHTMLHandlerService));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(ILotteryService));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<DuplaSena>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<MegaSena>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Loteca>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Federal>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoFacil>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoGol>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<LotoMania>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<Quina>));
            Assert.IsNotNull(service);
            service = _server.Host.Services.GetService(typeof(IRepository<TimeMania>));
            Assert.IsNotNull(service);
        }
        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;

            var relativePathToHostProject = @"..\..\..\..\LotteryApi";

            return Path.Combine(testProjectPath, relativePathToHostProject);
        }
    }
    public static class TestServices
    {
        public static IServiceCollection LoadDependencies(this IServiceCollection services)
        {
            //add all dependencies
            services.AddTransient<IWebServiceService, WebServiceService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IProcessLotteryService, ProcessLotteryService>();
            services.AddTransient<IHTMLHandlerService, HTMLHandlerService>();
            services.AddTransient<ILotteryService, LotteryService>();
            services.AddSingleton<IRepository<DuplaSena>, MongoRepository<DuplaSena>>();
            services.AddSingleton<IRepository<MegaSena>, MongoRepository<MegaSena>>();
            services.AddSingleton<IRepository<Loteca>, MongoRepository<Loteca>>();
            services.AddSingleton<IRepository<Federal>, MongoRepository<Federal>>();
            services.AddSingleton<IRepository<LotoFacil>, MongoRepository<LotoFacil>>();
            services.AddSingleton<IRepository<LotoGol>, MongoRepository<LotoGol>>();
            services.AddSingleton<IRepository<LotoMania>, MongoRepository<LotoMania>>();
            services.AddSingleton<IRepository<Quina>, MongoRepository<Quina>>();
            services.AddSingleton<IRepository<TimeMania>, MongoRepository<TimeMania>>();
            return services;
        }
    }
}
