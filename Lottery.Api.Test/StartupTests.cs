using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Net.Http;
using Xunit;


namespace LotteryApi.Test
{

    public class StartupTest
    {
        [Fact]
        [Trait("StartupTest", "Startup Test - Init .NET core app test")]
        public void Startup_Test()
        {
            CreateServer _server = new CreateServer();

            Assert.NotNull(_server.TestServerCreated);
            Assert.NotNull(_server.TestClient);
            // test each dependency injection if exists
            var service = _server.TestServerCreated.Host.Services.GetService(typeof(IWebServiceService));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IFileHandlerService));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IProcessLotteryService));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IHTMLHandlerService));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(ILotteryService));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<DuplaSena>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<MegaSena>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<Loteca>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<Federal>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<LotoFacil>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<LotoGol>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<LotoMania>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<Quina>));
            Assert.NotNull(service);
            service = _server.TestServerCreated.Host.Services.GetService(typeof(IRepository<TimeMania>));
            Assert.NotNull(service);
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
    public class CreateServer
    {
        public TestServer TestServerCreated { get; set; }
        public HttpClient TestClient { get; set; }
        public CreateServer()
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
            TestServerCreated = new TestServer(builder);
            // create http client
            TestClient = TestServerCreated.CreateClient();
        }
        public string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;

            var relativePathToHostProject = @"..\..\..\..\LotteryApi";

            return Path.Combine(testProjectPath, relativePathToHostProject);
        }
    }
}
