namespace CCC.WorkderService
{
	public class NotifyAlertEmailServiceConfiguration
    {
        public string Mode { get; set; }
        public string IntervalMinutes { get; set; }
        public string ScheduledTime { get; set; }
        public string APIURL { get; set; }
        public string apiKey { get; set; }
        public string ReplaceLogFile { get; set; }
        public string LogFileName { get; set; }
    }
}
