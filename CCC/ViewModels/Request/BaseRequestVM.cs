using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class BaseRequestVM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExp { get; set; }
        public string CreatorName { get; set; }
        public string ModifiorName { get; set; }
        public string RequesterUserId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
