using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;


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
            var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            // Create builder
            var builder = new WebHostBuilder()
                            .UseEnvironment("Testing")
                            .UseStartup<Startup>()
                            .ConfigureTestServices(services => services.LoadDependencies())
                            .UseConfiguration(configuration);
            // Create test server
            _server = new TestServer(builder);
            Assert.IsNotNull(_server);
            _client = _server.CreateClient();
            Assert.IsNotNull(_client);
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
