using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class VetMaster : BaseEntity
    {
        public string VetId { get; set; }
        public string VetName { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    public class VetMaster_Constant : BaseEntity_Constant
    {
        public const string VETID = "VetId";
        public const string VETNAME = "VetName";
        public const string EMAIL = "Email";
        public const string MOBILE = "Mobile";
        public const string ADDRESS = "Address";
        public const string DESCRIPTION = "Description";
        public const string REGISTRATIONNO = "RegistrationNo";


        public const string SPROC_VETMASTER_UPS = "sproc_VetMaster_ups";
        public const string SPROC_VETMASTER_SEL = "sproc_VetMaster_sel";
        public const string SPROC_VETMASTER_LSTALL = "sproc_VetMaster_lstAll";
        public const string SPROC_VETMASTER_DEL = "sproc_VetMaster_del";

        public const string SPROC_VETMASTER_GETALL = "sproc_VetMaster_GetAll";
        public const string SPROC_VETMASTER_ISVETNAMEINUSE = "sproc_VetMaster_IsVetNameInUse";
        public const string SPROC_VETMASTER_ISINCOUNTUSE = "sproc_VetMaster_IsInCountUse";
    }
}
