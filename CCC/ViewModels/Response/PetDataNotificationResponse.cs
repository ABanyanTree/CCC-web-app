using System;

namespace CCC.UI.ViewModels
{
	public class PetDataNotificationResponse
    {
        public string PetNotifyId { get; set; }
        public string ServiceId { get; set; }
        public string UserId { get; set; }
        public bool IsRead { get; set; }
        public bool IsAdminRead { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string PetType { get; set; }
        public string Gender { get; set; }
        public string CenterName { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public string SurgeryDateDisplay { get; set; }

        public int TotalCount { get; set; }
    }
}
