using CCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCC.Service.Interfaces
{
    public interface IPetDataNotificationService : IServiceBase<PetDataNotification>
    {
        Task<IEnumerable<PetDataNotification>> ReadPetDataByUser(string userId, bool IsAdmin);
        Task<PetDataNotification> GetPetUnReadData(string userId,bool IsAdmin);
        //Task<bool> SendMonthlyNotification(string reportFileName, string reportType, string toEmails);
        Task<bool> SendMonthlyNotification(string reportFileName, string reportType, string toEmails, string reportFullPath = "");
    }
}
