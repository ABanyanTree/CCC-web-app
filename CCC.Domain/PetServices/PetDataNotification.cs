using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class PetDataNotification
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
        public DateTime SurgeryDate { get; set; }
        public string SurgeryDateDisplay { get; set; }
        public int TotalCount { get; set; }
        public bool IsAdmin { get; set; }

    }

    public class PetDataNotification_Constant
    {
        public const string PETNOTIFYID = "PetNotifyId";
        public const string SERVICEID = "ServiceId";
        public const string USERID = "UserId";
        public const string ISREAD = "IsRead";
        public const string CREATEDDATE = "CreatedDate";
        public const string MODIFIEDDATE = "ModifiedDate";
        public const string ISADMIN = "IsAdmin";

        public const string SPROC_PETDATANOTIFICATION_UPS = "sproc_PetDataNotification_ups";
        public const string SPROC_PETDATANOTIFICATION_GETALL = "sproc_PetDataNotification_GetAll";
        public const string SPROC_PETDATANOTIFICATION_UPDATEASREAD = "sproc_PetDataNotification_UpdateAsRead";
        public const string SPROC_PETDATANOTIFICATION_GETUNREADCOUNT = "sproc_PetDataNotification_GetUnreadCount";

        public const string SPROC_PETDATANOTIFICATION_DEL = "sproc_PetDataNotification_del";

    }
}
