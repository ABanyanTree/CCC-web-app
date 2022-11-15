﻿using System;
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
        public string Gender { get; set; }
        public string CertificateNo { get; set; }
        public string TagId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string CenterId { get; set; }
        public string AreaId { get; set; }
        public string CareGiver { get; set; }
        public string VetId { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string MedicalNoteId { get; set; }

        public string PetType { get; set; }
        public string CenterName { get; set; }
        public string VetName { get; set; }
        public string AreaName { get; set; }
        public string MedicalComments { get; set; }
        public string VanNumber { get; set; }


        public string AdmissionDateDisplay { get; set; }
        public string SurgeryDateDisplay { get; set; }
        public string ReleaseDateDisplay { get; set; }

        public string VanId { get; set; }
        public bool? IsEarNotch { get; set; }
        public bool? IsARV { get; set; }
        public bool? IsOnHold { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CauseOfDeath { get; set; }
    }

    public class PetServiceDetails_Constant : BaseEntity_Constant
    {
        public const string SERVICEID = "ServiceId";
        public const string PETID = "PetId";
        public const string GENDER = "Gender";
        public const string CERTIFICATENO = "CertificateNo";
        public const string TAGID = "TagId";
        public const string ADMISSIONDATE = "AdmissionDate";
        public const string CENTERID = "CenterId";
        public const string AREAID = "AreaId";
        public const string CAREGIVER = "CareGiver";
        public const string VETID = "VetId";
        public const string SURGERYDATE = "SurgeryDate";
        public const string RELEASEDATE = "ReleaseDate";
        public const string MEDICALNOTEID = "MedicalNoteId";

        public const string VANID = "VanId";
        public const string ISEARNOTCH = "IsEarNotch";
        public const string ISARV = "IsARV";
        public const string ISONHOLD = "IsOnHold";
        public const string EXPIREDDATE = "ExpiredDate";
        public const string CAUSEOFDEATH = "CauseOfDeath";




        public const string SPROC_PETSERVICE_UPS = "sproc_PetService_ups";
        public const string SPROC_PETSERVICE_SEL = "sproc_PetService_sel";
        public const string SPROC_PETSERVICE_LSTALL = "sproc_PetService_lstAll";
        public const string SPROC_PETSERVICE_DEL = "sproc_PetService_del";


    }
}