using System;

namespace CCC.Domain
{
	public class ErrorLogs:BaseEntity
    {
        public string ErrorLogID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public DateTime? ErrorDateTime { get; set; }
        public DateTime? ErrorFromDate { get; set; }
        public DateTime? ErrorToDate { get; set; }
        public string ErrorDateDisplay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserDataXML { get; set; }
    }
    public class ErrorLogs_Constant : BaseEntity_Constant
    {
        public const string ERRORLOGID = "ErrorLogID";
        public const string CONTROLLERNAME = "ControllerName";
        public const string ACTIONNAME = "ActionName";
        public const string ERRORMESSAGE = "ErrorMessage";
        public const string INNEREXCEPTION = "InnerException";
        public const string STACKTRACE = "StackTrace";
        public const string ERRORDATETIME = "ErrorDateTime";

        public const string SPROC_ERRORS_UPS = "sproc_Errors_ups";
    }
}
