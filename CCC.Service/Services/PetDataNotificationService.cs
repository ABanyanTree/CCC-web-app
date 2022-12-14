using CCC.Domain;
using CCC.Domain.DomainInterface;
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
        public PetDataNotificationService(IPetDataNotificationRepository PetDataNotificationRepositoryy) : base()
        {
            _PetDataNotificationRepository = PetDataNotificationRepositoryy;
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
    }
}
