using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class PetServiceDetails : BaseEntity
    {
        public string ServiceId { get; set; }
        public string PetId { get; set; }
        public bool Gender { get; set; }
        public string CertificateNo { get; set; }
        public string TagId { get; set; }
        public DateTime EntryDate { get; set; }
        public string CenterId { get; set; }
        public string AreaId { get; set; }
        public string CareGiver { get; set; }
        public string VetId { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Complications { get; set; }
        public bool? IsExpired { get; set; }

        public string CenterName { get; set; }
        public string VetName { get; set; }
        public string AreaName { get; set; }

        public string EntryDateDisplay { get; set; }
        public string SurgeryDateDisplay { get; set; }
        public string ReleaseDateDisplay { get; set; }

    }

    public class PetServiceDetails_Constant : BaseEntity_Constant
    {
        public const string SERVICEID = "ServiceId";
        public const string PETID = "PetId";
        public const string GENDER = "Gender";
        public const string CERTIFICATENO = "CertificateNo";
        public const string TAGID = "TagId";
        public const string ENTRYDATE = "EntryDate";
        public const string CENTERID = "CenterId";
        public const string AREAID = "AreaId";
        public const string CAREGIVER = "CareGiver";
        public const string VETID = "VetId";
        public const string SURGERYDATE = "SurgeryDate";
        public const string RELEASEDATE = "ReleaseDate";
        public const string COMPLICATIONS = "Complications";
        public const string ISEXPIRED = "IsExpired";


        public const string SPROC_PETSERVICE_UPS = "sproc_PetService_ups";
        public const string SPROC_PETSERVICE_SEL = "sproc_PetService_sel";
        public const string SPROC_PETSERVICE_LSTALL = "sproc_PetService_lstAll";
        public const string SPROC_PETSERVICE_DEL = "sproc_PetService_del";


    }
}