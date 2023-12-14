using CCC.API.Installers;
using CCC.API.Scheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using CCC.API.Options;

namespace CCC.API
{
	public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
           
            builder.Services.InstallServicesInAssembly(builder.Configuration);
            
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            builder.Services.AddSwaggerGen(c =>
            { //<-- NOTE 'Add' instead of 'Configure'
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GTrackAPI",
                    Version = "v1"
                });
            });

            builder.Services.AddOptions();
            builder.Services.AddScoped<MonthlyReportTask>();

         
            var app = builder.Build();
            string cornExpr = Convert.ToString(app.Configuration.GetSection("CornJobConfig:CORN_Expr").Value);

            //Configure the Quartz Job
            ScheduleJob(app.Services, cornExpr).GetAwaiter().GetResult();

            //setup the pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            var swaggeroptions = new SwaggerOptions();
            app.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggeroptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggeroptions.JsonRoute;
            });

            if (swaggeroptions.ShowDefinition == "1")
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(swaggeroptions.UIEndpoint, swaggeroptions.Description);
                });
            }


            var corsSetting = new CorsSetting();
            app.Configuration.GetSection(nameof(CorsSetting)).Bind(corsSetting);


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(blder =>
            {
                blder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            string AllowAllDomain = app.Configuration.GetValue<string>("VersionSettings:AllowAllDomain");
            if (AllowAllDomain == "1")
            {
                app.Use(async (context, next) =>
                {
                    await next();
                });
            }
            else
            {
                app.Use(async (context, next) =>
                {
                    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN"); // Or this
                    await next();
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            app.Run();
        }


        private static async Task ScheduleJob(IServiceProvider serviceProvider, string cornExpr)
        {
            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            var factory = new StdSchedulerFactory(props);
            var sched = await factory.GetScheduler();
            sched.JobFactory = new Scheduler.TaskFactory(serviceProvider);

            await sched.Start();
            var job = JobBuilder.Create<MonthlyReportTask>()
                .WithIdentity("myJob", "group1")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .WithCronSchedule(cornExpr)
            .Build();
            await sched.ScheduleJob(job, trigger);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
