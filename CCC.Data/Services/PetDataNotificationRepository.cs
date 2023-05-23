using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class PetDataNotificationRepository : Repository<PetDataNotification>, IPetDataNotificationRepository
    {
        public PetDataNotificationRepository(IOptions<ReadConfig> connStr, IDapperResolver<PetDataNotification> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddPetDataNotification(PetDataNotification obj)
        {
            string[] argparam = { PetDataNotification_Constant.PETNOTIFYID, PetDataNotification_Constant.SERVICEID,
                PetDataNotification_Constant.USERID,PetDataNotification_Constant.ISADMIN };
            return await ExecuteNonQueryAsync(obj, argparam, PetDataNotification_Constant.SPROC_PETDATANOTIFICATION_UPS);
        }

        public async Task<PetDataNotification> GetPetUnReadData(string userId, bool IsAdmin)
        {
            PetDataNotification obj = new PetDataNotification() { UserId = userId, IsAdmin = IsAdmin };
            string[] argparam = { PetDataNotification_Constant.USERID, PetDataNotification_Constant.ISADMIN };
            return await GetAsync(obj, argparam, PetDataNotification_Constant.SPROC_PETDATANOTIFICATION_GETUNREADCOUNT);
        }

        public async Task<IEnumerable<PetDataNotification>> ReadPetDataByUser(string userId, bool IsAdmin)
        {
            PetDataNotification obj = new PetDataNotification() { UserId = userId, IsAdmin = IsAdmin };
            string[] argparam = { PetDataNotification_Constant.USERID, PetDataNotification_Constant.ISADMIN };
            return await GetAllAsync(obj, argparam, PetDataNotification_Constant.SPROC_PETDATANOTIFICATION_GETALL);
        }
    }
}
