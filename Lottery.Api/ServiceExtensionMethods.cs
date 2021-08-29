using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lottery.Api
{
    public static class ServiceExtensionMethods
    {

        public static IServiceCollection LoadDependencies(this IServiceCollection services)
        {
            //add all dependencies
            services.AddHttpClient<ICaixaWSService, CaixaWSService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IHtmlHandlerService, HtmlHandlerService>();
            services.AddTransient<ILotteryService, LotteryService>();
            services.AddTransient<IProcessLotteryFileService, ProcessLotteryFileService>();
            services.AddTransient<ILotteryDataBuilder, LotteryDataBuilder>();
            services.AddTransient<ILotteryFacade, LotteryFacade>();

            // This is part of all repositories based on lottery names
            services.AddSingleton(typeof(IRepository<>), typeof(MongoRepository<>));
            return services;
        }

        public static IServiceCollection LoadConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            // add config from appsettings.json to class
            var config = new AppSettings();
            var mongoDb = new MongoDBConfiguration();
            Configuration.Bind(nameof(AppSettings), config);
            Configuration.Bind(nameof(MongoDBConfiguration), mongoDb);
            services.AddSingleton(config);
            services.AddSingleton(mongoDb);

            return services;
        }
    }
}
