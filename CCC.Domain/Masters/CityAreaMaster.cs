using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class CityAreaMaster : BaseEntity
    {
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string CityId { get; set; }
        public string Description { get; set; }
    }

    public class CityAreaMaster_Constant : BaseEntity_Constant
    {
        public const string AREAID = "AreaId";
        public const string AREANAME = "AreaName";
        public const string CITYID = "CityId";
        public const string DESCRIPTION = "Description";

        public const string SPROC_CITYAREAMASTER_UPS = "sproc_CityAreaMaster_ups";
        public const string SPROC_CITYAREAMASTER_SEL = "sproc_CityAreaMaster_sel";
        public const string SPROC_CITYAREAMASTER_LSTALL = "sproc_CityAreaMaster_lstAll";
        public const string SPROC_CITYAREAMASTER_DEL = "sproc_CityAreaMaster_del";
    }
}
