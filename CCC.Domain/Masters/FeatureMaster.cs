using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class FeatureMaster
    {
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureLink { get; set; }
        public bool IsDashboardAvailable { get; set; }
        public string DashBoardLink { get; set; }
        public bool IsLinkAsMenu { get; set; }
        public string DashboardTitle { get; set; }
        public string ParentFeatureId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
