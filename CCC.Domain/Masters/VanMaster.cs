using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class VanMaster : BaseEntity
    {
        public string VanId { get; set; }
        public string VanNumber { get; set; }
        public string DriverName { get; set; }
        public string ContactNo { get; set; }
    }

    public class VanMaster_Constant : BaseEntity_Constant
    {
        public const string VANID = "VanId";
        public const string VANNUMBER = "VanNumber";
        public const string DRIVERNAME = "DriverName";
        public const string CONTACTNO = "ContactNo";

        public const string SPROC_VANMASTER_UPS = "sproc_VanMaster_ups";
        public const string SPROC_VANMASTER_SEL = "sproc_VanMaster_sel";
        public const string SPROC_VANMASTER_LSTALL = "sproc_VanMaster_lstAll";
        public const string SPROC_VANMASTER_DEL = "sproc_VanMaster_del";

        public const string SPROC_VANMASTER_GETALL = "sproc_VanMaster_GetAll";
        public const string SPROC_VANMASTER_ISVANNUMBERINUSE = "sproc_VanMaster_IsVanNumberInUse";
        public const string SPROC_VANMASTER_ISINCOUNTUSE = "sproc_VanMaster_IsInCountUse";


    }
}
