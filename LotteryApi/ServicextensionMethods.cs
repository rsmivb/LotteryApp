﻿using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LotteryApi
{
    public static class ServicextensionMethods
    {

        public static IServiceCollection LoadDependencies(this IServiceCollection services)
        {
            //add all dependencies
            services.AddTransient<IWebServiceService, WebServiceService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IProcessLotteryService, ProcessLotteryService>();
            services.AddTransient<IHtmlHandlerService, HtmlHandlerService>();
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

        public static IServiceCollection LoadConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            // add config from appsettings.json to class
            var config = new AppSettings();
            Configuration.Bind("AppSettings", config);
            services.AddSingleton<AppSettings>(config);

            return services;
        }
    }
}
