using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool InValidated { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string APIName { get; set; }
    }

    public class RefreshToken_Constant
    {
        public const string sproc_RefreshToken_Ups_Used = "sproc_RefreshToken_Ups_Used";
        public const string sproc_RefreshToken_Ups = "sproc_RefreshToken_Ups";
        public const string Token = "Token";
        public const string JwtId = "JwtId";
        public const string Creationdate = "Creationdate";
        public const string ExpiryDate = "ExpiryDate";
        public const string Used = "Used";
        public const string InValidated = "InValidated";
        public const string UserId = "UserId";
        public const string EmailAddress = "EmailAddress";
        public const string sproc_RefreshToken_Get = "sproc_RefreshToken_Get";
    }


}
