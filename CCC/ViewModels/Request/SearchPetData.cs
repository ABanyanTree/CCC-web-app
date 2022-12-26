using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class SearchPetData : BaseRequestVM
    {
        public string PetId { get; set; }
        public bool Gender { get; set; }
        public string CertificateNo { get; set; }
        public string TagId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string CenterId { get; set; }
        public string AreaId { get; set; }
        public string VetId { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string VanId { get; set; }

        public DateTime? AdmissionDateFrom { get; set; }
        public DateTime? AdmissionDateTo { get; set; }
        public DateTime? SurgeryDateFrom { get; set; }
        public DateTime? SurgeryDateTo { get; set; }
        public DateTime? ReleaseDateFrom { get; set; }
        public DateTime? ReleaseDateTo { get; set; }

        public string Month { get; set; }
        public string Year { get; set; }

        public string UserCenters { get; set; }

        public bool IsAdmin { get; set; }

    }
}
