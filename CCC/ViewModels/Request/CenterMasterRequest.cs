using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class CenterMasterRequest : BaseRequestVM
    {
        public string CenterId { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid center name.")]
        [Required(ErrorMessage = "Please enter center name")]
        [Remote("IsCenterNameInUse", "CenterMaster", ErrorMessage ="Center name is already exists.", HttpMethod = "GET")]
        public string CenterName { get; set; }

        [Required(ErrorMessage = "Please enter center address")]
        public string CenterAddress { get; set; }
        public string Description { get; set; }
    }
}
