using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class VetMasterRequest : BaseRequestVM
    {
        public string VetId { get; set; }
        public string VetName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
