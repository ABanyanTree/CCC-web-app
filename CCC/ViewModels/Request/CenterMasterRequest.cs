using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class CenterMasterRequest : BaseRequestVM
    {
        public string CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string Description { get; set; }
    }
}
