using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class LookupMasterRequest : BaseRequestVM
    {
        public string LookupId { get; set; }

        [Required(ErrorMessage = "Please enter lookup type")]
        public string LookupType { get; set; }
        public string LookupTypeText { get; set; }
        public string LookupName { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid lookup name.")]
        [Required(ErrorMessage = "Please enter lookup name")]
        public string LookupValue { get; set; }
        public int DisplayOrder { get; set; }
        //public bool IsActive { get; set; }
        public int TotalCount { get; set; }
    }
}
