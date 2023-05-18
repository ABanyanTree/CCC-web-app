using Quartz;
using System.IO;
using System;
using System.Threading.Tasks;
using CCC.Service.Interfaces;

namespace CCC.API.Scheduler
{
    public class MonthlyReportTask : IJob
    {
        private readonly INotificationService _notificationService;

        public MonthlyReportTask(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _notificationService.MonthlyReport();
            WriteFile(DateTime.Now);
            return Task.CompletedTask;    
        }


        public void WriteFile(DateTime time)
        {
            string path = "C:\\log\\sample.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(time);
                writer.Close();
            }
        }
    }
}
