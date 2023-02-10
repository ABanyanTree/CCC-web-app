using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Domain.Email;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
    public class PetDataNotificationService : IPetDataNotificationService
    {
        private IPetDataNotificationRepository _PetDataNotificationRepository;
        private IEmailSender _iEmailSender;
        public PetDataNotificationService(IPetDataNotificationRepository PetDataNotificationRepositoryy, IEmailSender EmailSender) : base()
        {
            _PetDataNotificationRepository = PetDataNotificationRepositoryy;
            _iEmailSender = EmailSender;
        }
        public async Task<int> AddEditAsync(PetDataNotification obj)
        {
            return await _PetDataNotificationRepository.AddPetDataNotification(obj);
        }

        public Task<int> DeleteAsync(PetDataNotification obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PetDataNotification>> GetAllAsync(PetDataNotification obj)
        {
            throw new NotImplementedException();
        }

        public Task<PetDataNotification> GetAsync(PetDataNotification obj)
        {
            throw new NotImplementedException();
        }

        public async Task<PetDataNotification> GetPetUnReadData(string userId, bool IsAdmin)
        {
            return await _PetDataNotificationRepository.GetPetUnReadData(userId, IsAdmin);
        }

        public async Task<IEnumerable<PetDataNotification>> ReadPetDataByUser(string userId, bool IsAdmin)
        {
            return await _PetDataNotificationRepository.ReadPetDataByUser(userId, IsAdmin);
        }

        public async Task<bool> SendMonthlyNotification(string reportFileName, string reportType, string toEmails)
        {
            bool IsEmailSend = false;
            if (!string.IsNullOrEmpty(toEmails))
            {
                string strBody = string.Empty;
                string strSubject = string.Empty;
                EmailSenderEntity emailconfig = new EmailSenderEntity();

                //EmailSender data = new EmailSender();
                _iEmailSender.GetReportNotificationBodySubject(reportType, reportFileName, ref strBody, ref strSubject);
                //data.GetForgotPasswordBodyAndSubject(obj, ref strBody, ref strSubject);
                emailconfig.EmailTo = toEmails;
                emailconfig.Body = strBody;
                emailconfig.Subject = strSubject;
                IsEmailSend = await _iEmailSender.SendInstantEmailFunctionality(emailconfig);
            }
            return IsEmailSend;
        }
    }
}
