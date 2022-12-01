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

        public async Task<string> AddEditLookup(LookupMaster obj)
        {
            if (string.IsNullOrEmpty(obj.LookupId))
            {
                obj.LookupId = Utility.GeneratorUniqueId("LKP_");
                obj.IsActive = true;
            }
            int ss = await _iLookupMasterRepository.AddEditLookup(obj);
            return obj.LookupId;
        }

        public async Task<int> DeleteAsync(LookupMaster obj)
        {
            return await _iLookupMasterRepository.DeleteLookup(obj);
        }

        public Task<IEnumerable<LookupMaster>> GetAllAsync(LookupMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupMaster>> GetAllLookupList(LookupMaster obj)
        {
            return await _iLookupMasterRepository.GetAllLookupList(obj);
        }

        public async Task<LookupMaster> GetAsync(LookupMaster obj)
        {
            return await _iLookupMasterRepository.GetLookup(obj);
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType)
        {
            return await _iLookupMasterRepository.GetLookupByType(lookupType);
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupTypes()
        {
            return await _iLookupMasterRepository.GetLookupTypes();
        }

        public async Task<LookupMaster> IsInUseCount(string lookupId)
        {
            return await _iLookupMasterRepository.IsInUseCount(lookupId);
        }

        public async Task<LookupMaster> IsLookupNameInUse(string lookupValue)
        {
            return await _iLookupMasterRepository.IsLookupNameInUse(lookupValue);
        }
    }
}
