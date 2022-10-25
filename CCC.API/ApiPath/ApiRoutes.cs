using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.ApiPath
{
    public static class ApiRoutes
    {
        public const string Base = "api";

        public static class PetServicesDetails
        {
            public const string AddEditPetData = Base + "/petservice/addeditpetdata";
            public const string GetPetData = Base + "/petservice/getpetdata";
            public const string GetAllPetData = Base + "/petservice/getallpetdata";
            public const string DeletePetData = Base + "/petservice/deletepetdata";
        }

        public static class CenterMaster
        {
            public const string AddEditCenter = Base + "/petservice/addeditcenter";
            public const string GetCenter = Base + "/petservice/getcenter";
            public const string GetAllCenterList = Base + "/petservice/getallcenterlist";
            public const string DeleteCenter = Base + "/petservice/deletecenter";
            
            public const string IsCenterNameInUse = Base + "/petservice/iscenternameinuse";
            public const string GetAllCenters = Base + "/petservice/getallcenters";
            public const string IsInUseCount = Base + "/petservice/isinusecount";

            
        }

    }
}
