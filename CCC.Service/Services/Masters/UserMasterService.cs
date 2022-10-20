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
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository _iUserMasterRepository;
        public UserMasterService(IUserMasterRepository UserMasterRepository) : base()
        {
            _iUserMasterRepository = UserMasterRepository;
        }

        public Task<int> AddEditAsync(UserMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserMaster>> GetAllAsync(UserMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserMaster> GetAsync(UserMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
