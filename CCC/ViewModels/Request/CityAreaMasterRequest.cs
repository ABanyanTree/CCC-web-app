using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class CityAreaMasterRequest : BaseRequestVM
    {
        public string AreaId { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid area name.")]
        [Required(ErrorMessage = "Please enter area name")]
        [Remote("IsAreaNameInUse", "CityAreaMaster", ErrorMessage = "Area name is already exists.", HttpMethod = "GET")]
        public string AreaName { get; set; }
        public string CityId { get; set; }
        public string Description { get; set; }
    }
}
