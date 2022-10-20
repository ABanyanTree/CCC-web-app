using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class CenterMaster : BaseEntity
    {
        public string CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string Description { get; set; }
    }

    public class CenterMaster_Constant : BaseEntity_Constant
    {
        public const string CENTERID = "CenterId";
        public const string CENTERNAME = "CenterName";
        public const string CENTERADDRESS = "CenterAddress";
        public const string DESCRIPTION = "Description";

        public const string SPROC_CENTERMASTER_UPS = "sproc_CenterMaster_ups";
        public const string SPROC_CENTERMASTER_SEL = "sproc_CenterMaster_sel";
        public const string SPROC_CENTERMASTER_LSTALL = "sproc_CenterMaster_lstAll";
        public const string SPROC_CENTERMASTER_DEL = "sproc_CenterMaster_del";
    }
}
