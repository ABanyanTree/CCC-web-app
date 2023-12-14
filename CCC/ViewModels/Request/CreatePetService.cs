using System;
using System.ComponentModel.DataAnnotations;

namespace CCC.UI.ViewModels
{
	public class CreatePetService
    {
        public string ServiceId { get; set; }

        [Required(ErrorMessage = "Please select Pet")]
        public string PetId { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter certification no")]
        public string CertificateNo { get; set; }

        [Required(ErrorMessage = "Please enter tag id")]
        public string TagId { get; set; }

        [Required(ErrorMessage = "Please enter admission date")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "Please select center")]
        public string CenterId { get; set; }

        [Required(ErrorMessage = "Please enter area")]
        public string AreaId { get; set; }
        public string CareGiver { get; set; }
        public string VetId { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string MedicalNoteId { get; set; }

        [Required(ErrorMessage = "Please select Van Number")]
        public string VanId { get; set; }
        public bool? IsNineInOne { get; set; }
        public bool? IsEarNotch { get; set; }
        public bool? IsARV { get; set; }
        public bool? IsOnHold { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CauseOfDeath { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string redirectFrom { get; set; }
        public string Color { get; set; }

    }
}
