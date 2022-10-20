using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class UserCenterMaster : BaseEntity
    {
        public string UserCenterId { get; set; }
        public string UserId { get; set; }
        public string CenterId { get; set; }
    }

    public class UserCenterMaster_Constant : BaseEntity_Constant
    {
        public const string USERCENTERID = "UserCenterId";
        public const string USERID = "UserId";
        public const string CENTERID = "CenterId";

        public const string SPROC_USERCENTERMASTER_UPS = "sproc_UserCenterMaster_ups";
        public const string SPROC_USERCENTERMASTER_SEL = "sproc_UserCenterMaster_sel";
        public const string SPROC_USERCENTERMASTER_LSTALL = "sproc_UserCenterMaster_lstAll";
        public const string SPROC_USERCENTERMASTER_DEL = "sproc_UserCenterMaster_del";
    }
}
