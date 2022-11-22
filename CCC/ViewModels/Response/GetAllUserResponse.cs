using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.ViewModels
{
    public class GetAllUserResponse
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLogin { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
        public string UserType { get; set; }
        public string CenterNames { get; set; }

        public List<FeatureMasterResponseVM> UserFeatures { get; set; } = new List<FeatureMasterResponseVM>();
        public List<UserRoleResponseVM> userRoles { get; set; } = new List<UserRoleResponseVM>();

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SortExp { get; set; }
    }
}
