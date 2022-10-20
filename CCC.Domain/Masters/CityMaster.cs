using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class CityMaster : BaseEntity
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
    }

    public class CityMaster_Constant : BaseEntity_Constant
    {
        public const string CITYID = "CityId";
        public const string CITYNAME = "CityName";
        public const string DESCRIPTION = "Description";

        public const string SPROC_CITYMASTER_UPS = "sproc_CityMaster_ups";
        public const string SPROC_CITYMASTER_SEL = "sproc_CityMaster_sel";
        public const string SPROC_CITYMASTER_LSTALL = "sproc_CityMaster_lstAll";
        public const string SPROC_CITYMASTER_DEL = "sproc_CityMaster_del";
    }
}
