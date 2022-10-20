using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class UserMaster
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LoginId { get; set; }
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
    }
}
