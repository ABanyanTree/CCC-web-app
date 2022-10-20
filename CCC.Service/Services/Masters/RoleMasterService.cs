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
    public class RoleMasterService : IRoleMasterService
    {
        private IRoleMasterRepository _iRoleMasterRepository;
        public RoleMasterService(IRoleMasterRepository RoleMasterRepository) : base()
        {
            _iRoleMasterRepository = RoleMasterRepository;
        }

        public Task<int> AddEditAsync(RoleMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(RoleMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleMaster>> GetAllAsync(RoleMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<RoleMaster> GetAsync(RoleMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
