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

        public static IServiceCollection LoadConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            // add config from appsettings.json to class
            var config = new AppSettings();
            var mongoDb = new MongoDBConfiguration();
            Configuration.Bind(nameof(AppSettings), config);
            Configuration.Bind(nameof(MongoDBConfiguration), mongoDb);
            services.AddSingleton<AppSettings>(config);
            services.AddSingleton<MongoDBConfiguration>(mongoDb);

            return services;
        }
    }
}
