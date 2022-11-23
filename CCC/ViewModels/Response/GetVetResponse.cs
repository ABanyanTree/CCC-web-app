using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class GetVetResponse : BaseResponse
    {
        public string VetId { get; set; }
        public string VetName { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
