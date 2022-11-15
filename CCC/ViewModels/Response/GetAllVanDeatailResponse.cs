using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class GetAllVanDeatailResponse : BaseResponse
    {
        public string VanId { get; set; }
        public string VanNumber { get; set; }
        public string DriverName { get; set; }
        public string ContactNo { get; set; }
    }
}
