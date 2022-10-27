using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class UserMaster : BaseEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }


        public bool IsLogin { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
        public List<FeatureMaster> Features { get; set; } = new List<FeatureMaster>();
        public List<UserRoleMasters> userRoles { get; set; } = new List<UserRoleMasters>();
    }


    //for Login purpose only
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserMaster_Constant : BaseEntity_Constant
    {
        public const string USERID = "UserId";
        public const string FIRSTNAME = "FirstName";
        public const string LASTNAME = "LastName";
        public const string EMAIL = "Email";
        public const string MOBILE = "Mobile";
        public const string LOGINID = "LoginId";
        public const string PASSWORD = "Password";

        public const string SPROC_USERMASTER_UPS = "sproc_UserMaster_ups";
        public const string SPROC_USERMASTER_SEL = "sproc_UserMaster_sel";
        public const string SPROC_USERMASTER_LSTALL = "sproc_UserMaster_lstAll";
        public const string SPROC_USERMASTER_DEL = "sproc_UserMaster_del";

        public const string SPROC_UserMaster_GETALL = "sproc_UserMaster_GetAll";
        public const string SPROC_USERMASTER_ISUSERNAMEINUSE = "sproc_UserMaster_IsUserNameInUse";
        public const string SPROC_UserMaster_ISINCOUNTUSE = "sproc_UserMaster_IsInCountUse";

        public const string SPROC_USERBYEMAIL = "sproc_UserByEmail";
        public const string SPROC_LOGINUSERBYEMAILPASSWORD = "sproc_LoginUserByEmailPassword";


    }
}
