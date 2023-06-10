using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class GetAllPetDataResponse
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

        public string VanId { get; set; }
        public bool? IsEarNotch { get; set; }
        public bool? IsARV { get; set; }
        public bool? IsOnHold { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CauseOfDeath { get; set; }

        public string PetType { get; set; }
        public string CenterName { get; set; }
        public string VetName { get; set; }
        public string AreaName { get; set; }
        public string MedicalComments { get; set; }
        public string VanNumber { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatorName { get; set; }
        public string ModifiorName { get; set; }
        public string AdmissionDateDisplay { get; set; }
        public string SurgeryDateDisplay { get; set; }
        public string ReleaseDateDisplay { get; set; }

        public bool? IsActive { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SortExp { get; set; }

        public DateTime? AdmissionDateFrom { get; set; }
        public DateTime? AdmissionDateTo { get; set; }
        public DateTime? SurgeryDateFrom { get; set; }
        public DateTime? SurgeryDateTo { get; set; }
        public DateTime? ReleaseDateFrom { get; set; }
        public DateTime? ReleaseDateTo { get; set; }

        public int OnHoldDays { get; set; }
        public bool IsAdmin { get; set; }

        public string Month { get; set; }
        public string Year { get; set; }

        //for display purpose
        public int totalSurgeryCount { get; set; }
        public int totalComplicationCount { get; set; }
        public decimal complicationPercentage { get; set; }
        public int totalDeathCount { get; set; }

        public string Color { get; set; }
        public string ColorValue { get; set; }
    }
}
