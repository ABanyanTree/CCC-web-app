using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface IPetDataNotificationRepository : IRepository<PetDataNotification>
    {
        Task<int> AddPetDataNotification(PetDataNotification obj);
        Task<IEnumerable<PetDataNotification>> ReadPetDataByUser(string userId, bool IsAdmin);
        Task<PetDataNotification> GetPetUnReadData(string userId, bool IsAdmin);
    }
}
