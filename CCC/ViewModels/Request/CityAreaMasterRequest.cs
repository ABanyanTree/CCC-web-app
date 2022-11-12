using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class CityAreaMasterRequest:BaseRequestVM
    {
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string CityId { get; set; }
        public string Description { get; set; }
    }
}
