using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class PetCountDetails
    {
        public string ServiceId { get; set; }
        public string CenterId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
