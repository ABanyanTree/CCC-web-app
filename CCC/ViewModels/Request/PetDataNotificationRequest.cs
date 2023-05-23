using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class PetDataNotificationRequest
    {
        public string PetNotifyId { get; set; }
        public string ServiceId { get; set; }
        public string UserId { get; set; }
        public bool IsRead { get; set; }
        public bool IsAdminRead { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
