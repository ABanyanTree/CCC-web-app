using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class CreatePetService
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
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
