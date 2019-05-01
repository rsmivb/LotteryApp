using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace LotteryApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.LoadConfiguration(Configuration);
            services.LoadDependencies();

            // Added Swashbuckle.AspNetCore
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Lottery Api", Version = "v1" });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lottery API V1");
            });
            app.UseMvc();
        }
    }

    public static class ServicextensionMethods
    {
        public static IServiceCollection LoadDependencies(this IServiceCollection services)
        {
            //add all dependencies
            services.AddSingleton<IFileHandlerService, FileHandlerService>();
            services.AddSingleton<IWebService, WebService>();
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
