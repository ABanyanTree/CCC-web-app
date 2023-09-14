using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class VanMasterRequest : BaseRequestVM
    {
        public string VanId { get; set; }

        //[RegularExpression(@"^[a-zA-Z]{2}[ -][0-9]{1,2}(?: [a-zA-Z])?(?: [a-zA-Z]*)? [0-9]{4}$", ErrorMessage = "Please enter valid van number.")]
        [Required(ErrorMessage = "Please enter van number")]
        //[Remote("IsVanNumberInUse", "VanMaster", ErrorMessage = "van number is already exists.", HttpMethod = "GET")]
        public string VanNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid driver name.")]
        [Required(ErrorMessage = "Please enter driver name")]
        public string DriverName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid mobile no")]
        [Required(ErrorMessage = "Please enter mobile no")]
        public string ContactNo { get; set; }
    }
}
