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
    public class LookupMasterService : ILookupMasterService
    {
        private ILookupMasterRepository _iLookupMasterRepository;
        public LookupMasterService(ILookupMasterRepository ILookupMasterRepository) : base()
        {
            _iLookupMasterRepository = ILookupMasterRepository;
        }

        public Task<int> AddEditAsync(LookupMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(LookupMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupMaster>> GetAllAsync(LookupMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<LookupMaster> GetAsync(LookupMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType)
        {
            return await _iLookupMasterRepository.GetLookupByType(lookupType);
        }
    }
}
