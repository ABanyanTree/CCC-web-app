using CCC.API.Installers;
using CCC.API.Middleware;
using CCC.API.Options;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

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
    }
}
