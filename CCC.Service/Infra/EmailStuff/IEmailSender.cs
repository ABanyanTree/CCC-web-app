using CCC.Domain;
using CCC.Domain.Email;
using System.Threading.Tasks;

namespace CCC.Service.Infra.EmailStuff
{
	public interface IEmailSender
    {
        Task<bool> SendInstantEmailFunctionality(EmailSenderEntity emailSenderEntity);
        void GetForgotPasswordBodyAndSubject(UserMaster obj, ref string body, ref string subject);
        void GetReportNotificationBodySubject(string reportType,string reportFileName, ref string strBody, ref string strSubject);

        Task<bool> SendInstantEmailForTesting(EmailSenderEntity emailSenderEntity);

        //Task<EmailSentLog> SendInstantEmail(EmailSenderEntity emailSenderEntity, Object Entity);
        //EmailSentLog GetBodyAndSubject(EmailSenderEntity emailSenderEntity, Object Entity);
        //Task<bool> SendPendingEmail(EmailSentLog emailSentLog);
        //string GetPrintCertficateContent(Assignments Entity);
        //Task<EmailSentLog> SendComplianceQuickLookInstantEmail(IEnumerable<CourseCompletionReport> lstData, string EmailTo, EmailSenderEntity emailSenderEntity);
        //string GetPrintCertficateContentDispatch(Assignments Entity);
    }
}
