using Quartz.Impl;
using Quartz;
using System;

namespace CCC.API.Scheduler
{
	public class SchedulerHandler
    {
        private static readonly string ScheduleCronExpression = "0 */5 * ? * *";
        public static async System.Threading.Tasks.Task StartAsync(string cornExpression)
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                var job1 = JobBuilder.Create<MonthlyReportTask>().WithIdentity("ExecuteTaskServiceCallJob1", "group1").Build();
                var trigger1 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger1", "group1").WithCronSchedule(cornExpression).Build();
                await scheduler.ScheduleJob(job1, trigger1);
            }
            catch (Exception ex) 
            {

            }
        }
    }
}
