using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class LookupMasterRequest
    {
        public string LookupId { get; set; }
        public string LookupType { get; set; }
        public string LookupTypeText { get; set; }
        public string LookupName { get; set; }
        public string LookupValue { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }
    }
}
