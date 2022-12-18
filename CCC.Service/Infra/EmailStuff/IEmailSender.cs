using CCC.Domain.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Infra.EmailStuff
{
    public interface IEmailSender
    {
        Task<EmailSentLog> SendInstantEmail(EmailSenderEntity emailSenderEntity, Object Entity);
        EmailSentLog GetBodyAndSubject(EmailSenderEntity emailSenderEntity, Object Entity);
        Task<bool> SendPendingEmail(EmailSentLog emailSentLog);
        //string GetPrintCertficateContent(Assignments Entity);
        //Task<EmailSentLog> SendComplianceQuickLookInstantEmail(IEnumerable<CourseCompletionReport> lstData, string EmailTo, EmailSenderEntity emailSenderEntity);
        //string GetPrintCertficateContentDispatch(Assignments Entity);
    }
}
