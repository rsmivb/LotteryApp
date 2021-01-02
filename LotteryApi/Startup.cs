using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace LotteryApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.LoadConfiguration(Configuration);
            services.LoadDependencies();

            services.AddControllers();

            // Added Swashbuckle.AspNetCore
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Lottery Api",
                        Description = "API which consumes data from Loterias Caixa and provides all lotteries results.",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Rafael Mesquita",
                            Email = "mesquita.cob@gmail.com",
                            Url = new Uri("https://github.com/rsmivb/LotteryApp")
                        }
                    });
                //Swagger documentation: https://medium.com/tableless/documenta%C3%A7%C3%A3o-de-apis-com-swagger-no-asp-net-core-e7bc3caa9185
                var applicationBasePath = Environment.CurrentDirectory;
                var applicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    options.IncludeXmlComments(xmlDocumentPath);
                }
                // https://blog.zhaytam.com/2018/09/23/generate-aspnetcore-web-api-doc-swagger/
                //enables annotations for each end point
                options.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lottery API V1");
                });
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
