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

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatorName { get; set; }
        public string ModifiorName { get; set; }
        public string EntryDateDisplay { get; set; }
        public string SurgeryDateDisplay { get; set; }
        public string ReleaseDateDisplay { get; set; }

        public bool? IsActive { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SortExp { get; set; }
    }
}
