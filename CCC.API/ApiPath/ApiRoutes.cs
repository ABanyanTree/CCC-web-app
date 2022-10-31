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
            public const string AddEditCenter = Base + "/centerMaster/addeditcenter";
            public const string GetCenter = Base + "/centerMaster/getcenter";
            public const string GetAllCenterList = Base + "/centerMaster/getallcenterlist";
            public const string DeleteCenter = Base + "/centerMaster/deletecenter";
            
            public const string IsCenterNameInUse = Base + "/centerMaster/iscenternameinuse";
            public const string GetAllCenters = Base + "/centerMaster/getallcenters";
            public const string IsInUseCount = Base + "/centerMaster/isinusecount";            
        }

        public static class CityAreaMaster
        {
            public const string AddEditCityArea = Base + "/cityareamaster/addeditcityarea";
            public const string GetCityArea = Base + "/cityareamaster/getcityarea";
            public const string GetAllCityAreaList = Base + "/cityareamaster/getallcityarealist";
            public const string DeleteCityArea = Base + "/cityareamaster/deleteCityarea";

            public const string IsCityAreaNameInUse = Base + "/cityareamaster/iscityareanameinuse";
            public const string GetAllCityAreas = Base + "/cityareamaster/getallcityareas";
            public const string IsInUseCount = Base + "/cityareamaster/isinusecount";
        }

        public static class VetMaster
        {
            public const string AddEditVetDetail = Base + "/vetmaster/addeditvetdetail";
            public const string GetVetDetail = Base + "/vetmaster/getvetdetail";
            public const string GetAllVetList = Base + "/vetmaster/getallvetlist";
            public const string DeleteVet = Base + "/vetmaster/deletevet";

            public const string IsVetNameInUse = Base + "/vetmaster/isvetnameinuse";
            public const string GetAllVetDetails = Base + "/vetmaster/getallvetdetails";
            public const string IsInUseCount = Base + "/vetmaster/isinusecount";
        }

        public static class UserMaster
        {
            public const string AddEditUser = Base + "/usermaster/addedituser";
            public const string GetUser = Base + "/usermaster/getuser";
            public const string GetAllUserList = Base + "/usermaster/getalluserlist";
            public const string DeleteUser = Base + "/usermaster/deleteuser";

            public const string IsUserNameInUse = Base + "/usermaster/isusernameinuse";
            public const string GetAllUsers = Base + "/usermaster/getallusers";
            public const string IsInUseCount = Base + "/usermaster/isinusecount";
            public const string Login = Base + "/usermaster/login";

            public const string GetSalt = Base + "/usermaster/getsalt";

            

        }

    }
}
