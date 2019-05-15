using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info {
                                Title = "Lottery Api",
                                Description = "API which consumes data from Loterias Caixa and provides all lotteries results.",
                                Version = "v1",
                                Contact = new Contact
                                {
                                    Name = "Rafael Mesquita",
                                    Email = "mesquita.cob@gmail.com",
                                    Url = "https://github.com/rsmivb/LotteryApp"
                                }
                            });
                //Swagger documentation: https://medium.com/tableless/documenta%C3%A7%C3%A3o-de-apis-com-swagger-no-asp-net-core-e7bc3caa9185
                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    options.IncludeXmlComments(xmlDocumentPath);
                }
                // https://blog.zhaytam.com/2018/09/23/generate-aspnetcore-web-api-doc-swagger/
                //enables annotations for each end point
                options.EnableAnnotations();
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
                c.RoutePrefix = "swagger";
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
