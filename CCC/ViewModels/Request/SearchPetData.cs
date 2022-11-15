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
    }
}
