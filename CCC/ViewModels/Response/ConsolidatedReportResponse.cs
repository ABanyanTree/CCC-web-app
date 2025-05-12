using System;

namespace CCC.UI.ViewModels.Response
{
    public class ConsolidatedReportResponse
    {
        public string SurgeryMonthYearShort { get; set; }
        public int SurgeryYear { get; set; }
        public int SurgeryMonth { get; set; }
        public string CenterName { get; set; }
        public string Species { get; set; }

        public int SurgeryCount { get; set; }
        public int rowIndex { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalCount { get; set; }
        public int DeathCount { get; set; }
        public int ComplicationCount { get; set; }
        public string CenterId { get; set; }

        public string Gender { get; set; }
        
    }
}
