using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
	public class UserCenterMasterService : IUserCenterMasterService
    {
        private IUserCenterMasterRepository _iUserCenterMasterRepository;
        public UserCenterMasterService(IUserCenterMasterRepository UserCenterMasterRepository) : base()
        {
            _iUserCenterMasterRepository = UserCenterMasterRepository;
        }

        public Task<int> AddEditAsync(UserCenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserCenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCenterMaster>> GetAllAsync(UserCenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserCenterMaster> GetAsync(UserCenterMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
