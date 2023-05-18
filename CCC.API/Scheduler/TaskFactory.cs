using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;

namespace CCC.API.Scheduler
{
    public class TaskFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private WebApplication _app;

        public TaskFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return scope.ServiceProvider.GetRequiredService<MonthlyReportTask>();
            }
        }

        public void ReturnJob(IJob job)
        {
            (job as IDisposable)?.Dispose();
        }
    }
}
