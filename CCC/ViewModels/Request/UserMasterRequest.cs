using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCC.UI.ViewModels
{
	public class UserMasterRequest : BaseRequestVM
    {
        public string UserId { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid name.")]
        [Required(ErrorMessage = "Please enter name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z ']*$", ErrorMessage = "Please enter valid name.")]
        [Required(ErrorMessage = "Please enter name")]
        public string LastName { get; set; }
        public string UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Please enter valid email address")]
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid mobile no")]
        public string Mobile { get; set; }
        public string LoginId { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLogin { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
        public string CenterIds { get; set; }      
        public string UserRole { get; set; }
        public string UserType { get; set; }
        public string CenterNames { get; set; }
        public string UserCenters { get; set; }
        public List<CenterMasterRequest> lstCenters { get; set; } = new List<CenterMasterRequest>();
        public List<FeatureMasterResponseVM> UserFeatures { get; set; } = new List<FeatureMasterResponseVM>();
        public List<UserRoleResponseVM> userRoles { get; set; } = new List<UserRoleResponseVM>();
    }
}
