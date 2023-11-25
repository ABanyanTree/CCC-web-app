using CCC.API.Installers;
using CCC.API.Middleware;
using CCC.API.Options;
using CCC.API.Scheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CCC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            //var cornExpr = configuration.GetSection("CORN_Expr");
            //SchedulerHandler.StartAsync(cornExpr.Value).GetAwaiter().GetResult();
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<MonthlyReportTask>();
            services.InstallServicesInAssembly(Configuration);
            //services.AddSingleton<FileHandlerMiddleWare>();
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            services.AddSwaggerGen(c =>
            { //<-- NOTE 'Add' instead of 'Configure'
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GTrackAPI",
                    Version = "v1"
                });
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var serviceProvider = app.ApplicationServices;
            string cornExpr = Convert.ToString(Configuration.GetSection("CORN_Expr").Value);
            ScheduleJob(serviceProvider, cornExpr).GetAwaiter().GetResult();

            var swaggeroptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggeroptions);

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
            Configuration.GetSection(nameof(CorsSetting)).Bind(corsSetting);

          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            string AllowAllDomain = Configuration.GetValue<string>("VersionSettings:AllowAllDomain");
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
        }

        private static async Task ScheduleJob(IServiceProvider serviceProvider,string cornExpr)
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
    }
}
