using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
	public class RoleFeatureMasterService : IRoleFeatureMasterService
    {
        private IRoleFeatureMasterRepository _iRoleFeatureMasterRepository;
        public RoleFeatureMasterService(IRoleFeatureMasterRepository RoleFeatureMasterRepository) : base()
        {
            _iRoleFeatureMasterRepository = RoleFeatureMasterRepository;
        }

        public Task<int> AddEditAsync(RoleFeatureMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(RoleFeatureMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleFeatureMaster>> GetAllAsync(RoleFeatureMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<RoleFeatureMaster> GetAsync(RoleFeatureMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
