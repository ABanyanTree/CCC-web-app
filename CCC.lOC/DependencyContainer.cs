using CCC.Data.Interfaces;
using CCC.Data.Services;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using CCC.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.lOC
{
    public class DependencyContainer
    {
        public string newstr { get; set; }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IDapperResolver<>), typeof(DapperResolver<>));

            services.AddSingleton<IErrorLogs, ErrorLogsService>();
            services.AddSingleton<IErrorLogsRepository, ErrorLogsRepository>();

            services.AddSingleton<IPetServices, PetService>();
            services.AddSingleton<IPetRepository, PetRepository>();
        }
    }
}
